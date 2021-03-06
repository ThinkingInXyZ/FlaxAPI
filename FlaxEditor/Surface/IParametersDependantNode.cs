﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

namespace FlaxEditor.Surface
{
    /// <summary>
    /// Interface for surface nodes that depend on surface parameters collection.
    /// </summary>
    public interface IParametersDependantNode
    {
        /// <summary>
        /// On new parameter created
        /// </summary>
        /// <param name="param">The paramater.</param>
        void OnParamCreated(SurfaceParameter param);

        /// <summary>
        /// On new parameter renamed
        /// </summary>
        /// <param name="param">The paramater.</param>
        void OnParamRenamed(SurfaceParameter param);
	
        /// <summary>
        /// On new parameter deleted
        /// </summary>
        /// <param name="param">The paramater.</param>
        void OnParamDeleted(SurfaceParameter param);
    }
}
