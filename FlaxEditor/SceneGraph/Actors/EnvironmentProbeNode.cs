////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEngine;

namespace FlaxEditor.SceneGraph.Actors
{
    /// <summary>
    /// Scene tree node for <see cref="EnvironmentProbe"/> actor type.
    /// </summary>
    /// <seealso cref="ActorNodeWithIcon" />
    public sealed class EnvironmentProbeNode : ActorNodeWithIcon
    {
        /// <inheritdoc />
        public EnvironmentProbeNode(Actor actor)
            : base(actor)
        {
        }
    }
}
