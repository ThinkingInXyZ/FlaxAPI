////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.Content;
using FlaxEngine;
using FlaxEngine.GUI;
using FlaxEngine.GUI.Docking;

namespace FlaxEditor.Windows
{
    /// <summary>
    ///  Base class for all windows in Editor.
    /// </summary>
    /// <seealso cref="FlaxEngine.GUI.Docking.DockWindow" />
    public abstract class EditorWindow : DockWindow
    {
        /// <summary>
        /// Gets the editor object.
        /// </summary>
        public readonly Editor Editor;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="hideOnClose">True if hide window on closing, otherwise it will be destroyed.</param>
        /// <param name="scrollBars">The scroll bars.</param>
        protected EditorWindow(Editor editor, bool hideOnClose, ScrollBars scrollBars)
            : base(editor.UI.MasterPanel, hideOnClose, scrollBars)
        {
            Editor = editor;

            // Register
            Editor.Windows.Windows.Add(this);
        }

        /// <summary>
        /// Determines whether this window is holding reference to the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if window is editing the specified item; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsEditingItem(ContentItem item)
        {
            return false;
        }

        #region Window Events

        /// <summary>
        /// Fired when scene starts saving
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneSaving(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene gets saved
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneSaved(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene gets saving error
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneSaveError(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene starts loading
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneLoading(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene gets loaded
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneLoaded(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene cannot be loaded
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneLoadError(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene gets unloading
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneUnloading(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Fired when scene gets unloaded
        /// </summary>
        /// <param name="scene">The scene object. It may be null!</param>
        /// <param name="sceneId">The scene ID.</param>
        public virtual void OnSceneUnloaded(Scene scene, Guid sceneId)
        {
        }

        /// <summary>
        /// Called when Editor is entering play mode.
        /// </summary>
        public virtual void OnPlayBegin()
        {
        }

        /// <summary>
        /// Called when Editor leaves the play mode.
        /// </summary>
        public virtual void OnPlayEnd()
        {
        }

        /// <summary>
        /// Called when window should be initializated.
        /// At this point, main window, content database, default editor windows are ready.
        /// </summary>
        public virtual void OnInit()
        {
        }

        /// <summary>
        /// Called when editor is being closed and window should perform release data operations.
        /// </summary>
        public virtual void OnExit()
        {
        }

        #endregion

        /// <inheritdoc />
        public override void OnDestroy()
        {
            // Unregister
            Editor.Windows.Windows.Remove(this);

            base.OnDestroy();
        }
    }
}
