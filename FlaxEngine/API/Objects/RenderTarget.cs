////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace FlaxEngine.Rendering
{
    public partial class RenderTarget
    {
        /// <summary>
        /// Returns true if texture has size that is power of two.
        /// </summary>
        public bool IsPowerOfTwo => Mathf.IsPowerOfTwo(Width) && Mathf.IsPowerOfTwo(Height);

        private class Temporary
        {
            public RenderTarget Texture;
            public bool IsFree;
            public float LastUsage;

            public Temporary(PixelFormat format, int width, int height, TextureFlags flags)
            {
                Texture = New();
                Texture.Init(format, width, height, flags);
            }

            public bool TryReuse(PixelFormat format, int width, int height, TextureFlags flags)
            {
                return IsFree
                       && Texture.Format == format
                       && Texture.Width == width
                       && Texture.Height == height
                       && Texture.Flags == flags;
            }

            public RenderTarget OnUse()
            {
                IsFree = false;
                LastUsage = Time.UnscaledTime;
                return Texture;
            }
        }

        private static readonly List<Temporary> _tmpRenderTargets = new List<Temporary>(8);

        /// <summary>
        /// The timout value for unused temporary render targets (in seconds).
        /// When render target is not used for a given amount of time, it's being released.
        /// </summary>
        public static float UnusedTemporaryRenderTargetLifeTime = 5.0f;

        /// <summary>
        /// Allocates a temporary render target.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The width in pixels.</param>
        /// <param name="height">The height in pixels.</param>
        /// <param name="flags">The texture usage flags.</param>
        /// <returns>Created texture.</returns>
        public static RenderTarget GetTemporary(PixelFormat format, int width, int height, TextureFlags flags = TextureFlags.ShaderResource | TextureFlags.RenderTarget)
        {
            // Try reuse
            for (int i = 0; i < _tmpRenderTargets.Count; i++)
            {
                if (_tmpRenderTargets[i].TryReuse(format, width, height, flags))
                {
                    return _tmpRenderTargets[i].OnUse();
                }
            }

            // Allocate new
            var target = new Temporary(format, width, height, flags);
            _tmpRenderTargets.Add(target);
            return target.OnUse();
        }

        /// <summary>
        /// Releases a temporary render target allocated using <see cref="GetTemporary"/>.
        /// Later calls to <see cref="GetTemporary"/> will reuse the RenderTexture created earlier if possible.
        /// When no one has requested the temporary RenderTexture for a few frames it will be destroyed.
        /// </summary>
        /// <param name="temp">The temporary.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ReleaseTemporary(RenderTarget temp)
        {
            for (int i = 0; i < _tmpRenderTargets.Count; i++)
            {
                if (_tmpRenderTargets[i].Texture == temp)
                {
                    _tmpRenderTargets[i].IsFree = true;
                    return;
                }
            }

            throw new InvalidOperationException("Cannot release render target.");
        }

        static RenderTarget()
        {
            Scripting.Update += Update;
        }

        private static void Update()
        {
            // Flush old unused render targets
            var time = Time.UnscaledTime;
            for (int i = 0; i < _tmpRenderTargets.Count; i++)
            {
                if (time - _tmpRenderTargets[i].LastUsage >= UnusedTemporaryRenderTargetLifeTime)
                {
                    // Recycle
                    Destroy(_tmpRenderTargets[i].Texture);
                    _tmpRenderTargets.RemoveAt(i);
                }
            }
        }
    }
}
