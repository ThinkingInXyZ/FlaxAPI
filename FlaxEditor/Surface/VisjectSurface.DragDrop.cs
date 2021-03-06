﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System.Threading;
using FlaxEditor.Content;
using FlaxEditor.GUI.Drag;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Surface
{
    public partial class VisjectSurface
    {
        private DragAssets _dragOverItems = new DragAssets();

        /// <inheritdoc />
        public override DragDropEffect OnDragEnter(ref Vector2 location, DragData data)
        {
            var result = base.OnDragEnter(ref location, data);

            if (result == DragDropEffect.None)
            {
                if (_dragOverItems.OnDragEnter(data, ValidateDragItemFunc))
                {
                    result = _dragOverItems.Effect;
                }
            }

            return result;
        }

        /// <inheritdoc />
        public override DragDropEffect OnDragMove(ref Vector2 location, DragData data)
        {
            var result = base.OnDragMove(ref location, data);

            if (result == DragDropEffect.None && _dragOverItems.HasValidDrag)
            {
                result = _dragOverItems.Effect;
            }

            return result;
        }

        /// <inheritdoc />
        public override void OnDragLeave()
        {
            _dragOverItems.OnDragLeave();

            base.OnDragLeave();
        }

        /// <inheritdoc />
        public override DragDropEffect OnDragDrop(ref Vector2 location, DragData data)
        {
            var result = base.OnDragDrop(ref location, data);

            if (result == DragDropEffect.None && _dragOverItems.HasValidDrag)
            {
                var surfaceLocation = _surface.PointFromParent(location);

                switch (Type)
                {
                    case SurfaceType.Material:
                    {
                        for (int i = 0; i < _dragOverItems.Objects.Count; i++)
                        {
                            var item = _dragOverItems.Objects[i];

                            switch (item.ItemDomain)
                            {
                                case ContentDomain.Texture:
                                {
                                    // Check if it's a normal map
                                    bool isNormalMap = false;
                                    var obj = FlaxEngine.Content.LoadAsync<Texture>(item.ID);
                                    if (obj)
                                    {
                                        Thread.Sleep(50);

                                        if (!obj.WaitForLoaded())
                                        {
                                            isNormalMap = obj.IsNormalMap;
                                        }
                                    }

                                    SpawnNode(5, (ushort)(isNormalMap ? 4 : 1), surfaceLocation, new object[] { item.ID });
                                    break;
                                }

                                case ContentDomain.CubeTexture:
                                {
                                    SpawnNode(5, 3, surfaceLocation, new object[] { item.ID });
                                    break;
                                }

                                case ContentDomain.Material:
                                {
                                    SpawnNode(8, 1, surfaceLocation, new object[] { item.ID });
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }
            }

            return result;
        }

        private bool ValidateDragItemFunc(AssetItem assetItem)
        {
            switch (Type)
            {
                case SurfaceType.Material:
                {
                    switch (assetItem.ItemDomain)
                    {
                        case ContentDomain.Texture:
                        case ContentDomain.CubeTexture:
                        case ContentDomain.Material: return true;
                    }
                    break;
                }
            }
            return false;
        }
    }
}
