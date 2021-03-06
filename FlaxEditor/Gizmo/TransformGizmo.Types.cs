﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

namespace FlaxEditor.Gizmo
{
    public partial class TransformGizmo
    {
        /// <summary>
        /// Gizmo axis modes.
        /// </summary>
        public enum Axis
        {
            /// <summary>
            /// None.
            /// </summary>
            None,

            /// <summary>
            /// The X axis.
            /// </summary>
            X,

            /// <summary>
            /// The Y axis.
            /// </summary>
            Y,

            /// <summary>
            /// The Z axis.
            /// </summary>
            Z,

            /// <summary>
            /// The XY plane.
            /// </summary>
            XY,

            /// <summary>
            /// The ZX plane.
            /// </summary>
            ZX,

            /// <summary>
            /// The YZ plane.
            /// </summary>
            YZ,

            /// <summary>
            /// The center point.
            /// </summary>
            Center,
        };

        /// <summary>
        /// Gizmo tool mode.
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// Translate object(s)
            /// </summary>
            Translate,

            /// <summary>
            /// Rotate object(s)
            /// </summary>
            Rotate,

            /// <summary>
            /// Scale object(s)
            /// </summary>
            Scale
        }

        /// <summary>
        /// Tranform object space.
        /// </summary>
        public enum TransformSpace
        {
            /// <summary>
            /// Object local space coordinates
            /// </summary>
            Local,

            /// <summary>
            /// World space coordinates
            /// </summary>
            World
        }

        /// <summary>
        /// Pivot location type.
        /// </summary>
        public enum PivotType
        {
            /// <summary>
            /// First selected object ssenter
            /// </summary>
            ObjectCenter,

            /// <summary>
            /// Selection pool center point
            /// </summary>
            SelectionCenter,

            /// <summary>
            /// World origin
            /// </summary>
            WorldOrigin
        }
    }
}
