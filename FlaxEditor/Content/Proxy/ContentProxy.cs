////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.Windows;
using FlaxEngine;

namespace FlaxEditor.Content
{
    /// <summary>
    /// Base class for asstes proxy objects used to manage <see cref="ContentItem"/>.
    /// </summary>
    public abstract class ContentProxy
    {
        /// <summary>
        /// Gets the asset type name (used by GUI, should be localizable).
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Determines whether this proxy is for the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if is proxy for asset item; otherwise, <c>false</c>.</returns>
        public abstract bool IsProxyFor(ContentItem item);

        /// <summary>
        /// Gets a value indicating whether this proxy if for assets.
        /// </summary>
        public virtual bool IsAsset => false;

        /// <summary>
        /// Gets the file extension used by the items managed by this proxy.
        /// ALL LOWERCASE! WITHOUT A DOT! example: for 'myFile.TxT' proper extension is 'txt'
        /// </summary>
        public abstract string FileExtension { get; }

        /// <summary>
        /// Opens the specified item.
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="item">The item.</param>
        /// <returns>Opened window or null if cannot do it.</returns>
        public abstract EditorWindow Open(Editor editor, ContentItem item);

        /// <summary>
        /// Gets a value indicating whether content items used by this proxy can be exported.
        /// </summary>
        public virtual bool CanExport => false;

        /// <summary>
        /// Exports the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="outputPath">The output path.</param>
        public virtual void Export(ContentItem item, string outputPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether this proxy can create items in the specified target location.
        /// </summary>
        /// <param name="targetLocation">The target location.</param>
        /// <returns><c>true</c> if this proxy can create items in the specified target location; otherwise, <c>false</c>.</returns>
        public virtual bool CanCreate(ContentFolder targetLocation)
        {
            return false;
        }

        /// <summary>
        /// Determines whether this proxy can reimport specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if this proxy can reimport given item; otherwise, <c>false</c>.</returns>
        public virtual bool CanReimport(ContentItem item)
        {
            return CanCreate(item.ParentFolder);
        }

        /// <summary>
        /// Creates new item at the specified output path.
        /// </summary>
        /// <param name="outputPath">The output path.</param>
        public virtual void Create(string outputPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the unique accent color for that asset type.
        /// </summary>
        public abstract Color AccentColor { get; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
