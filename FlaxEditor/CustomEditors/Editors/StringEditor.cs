////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEditor.CustomEditors.Elements;
using FlaxEngine;

namespace FlaxEditor.CustomEditors.Editors
{
    /// <summary>
    /// Default implementation of the inspector used to edit string properties.
    /// </summary>
    [CustomEditor(typeof(string)), DefaultEditor]
    public sealed class StringEditor : CustomEditor
    {
        private TextBoxElement element;

        /// <inheritdoc />
        public override bool IsInline => true;

        /// <inheritdoc />
        public override void Initialize(LayoutElementsContainer layout)
        {
            if (Values == null)
                return;

            element = layout.TextBox();
            element.TextBox.EditEnd += OnTextChanged;
        }

        private void OnTextChanged()
        {
            // TODO: block events during values refresh

            // TODO: update values, send mark dirty event or sth

            Debug.Log("-----> text changed to " + element.Text);
        }

        /// <inheritdoc />
        public override void Refresh()
        {
            if (HasDiffrentValues)
            {
                element.TextBox.Text = string.Empty;
                element.TextBox.WatermarkText = "Different Values";
            }
            else
            {
                element.TextBox.Text = (string)Values[0];
                element.TextBox.WatermarkText = string.Empty;
            }
        }
    }
}