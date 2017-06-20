////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
	/// <summary>
	/// Sprite atlas texture made of collection of sprites.
	/// </summary>
	public partial class SpriteAtlas : BinaryAsset
	{
		/// <summary>
		/// Gets the sprite by name.
		/// </summary>
		/// <param name="name">The sprite name.</param>
		/// <returns>Sprite handle (may be invalid if cannot find it).</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public Sprite GetSprite(string name) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Sprite resultAsRef;
			Internal_GetSprite(unmanagedPtr, name, out resultAsRef);
			return resultAsRef;
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetSprite(IntPtr obj, string name, out Sprite resultAsRef);
#endif
#endregion
	}
}
