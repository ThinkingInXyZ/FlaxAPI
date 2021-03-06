////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEditor.Gizmo;
using FlaxEngine;
using FlaxEngine.Rendering;

namespace FlaxEditor.Viewport
{
    /// <summary>
    /// Viewport with free camera and gizmo tools.
    /// </summary>
    /// <seealso cref="FlaxEditor.Viewport.EditorViewportFPSCam" />
    public class EditorGizmoViewport : EditorViewportFPSCam, IGizmoOwner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorGizmoViewport"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="undo">The undo.</param>
        public EditorGizmoViewport(SceneRenderTask task, Undo undo)
            : base(task, true)
        {
            task.Draw += OnDraw;
            Undo = undo;
        }

        private void OnDraw(DrawCallsCollector collector)
        {
            for (int i = 0; i < Gizmos.Count; i++)
            {
                Gizmos[i].Draw(collector);
            }
        }

        /// <inheritdoc />
        public GizmosCollection Gizmos { get; } = new GizmosCollection();

        /// <inheritdoc />
        public float ViewFarPlane => _farPlane;

        /// <inheritdoc />
        public bool IsLeftMouseButtonDown => _input.IsMouseLeftDown;

        /// <inheritdoc />
        public bool IsRightMouseButtonDown => _input.IsMouseRightDown;

        /// <inheritdoc />
        public Vector2 MouseDelta => _mouseDeltaLeft * 1000;

        /// <inheritdoc />
        public bool UseSnapping => ParentWindow.GetKey(Keys.Control);
        
        /// <inheritdoc />
        public Undo Undo { get; }

        /// <inheritdoc />
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            for (int i = 0; i < Gizmos.Count; i++)
            {
                Gizmos[i].Update(deltaTime);
            }
        }
    }
}
