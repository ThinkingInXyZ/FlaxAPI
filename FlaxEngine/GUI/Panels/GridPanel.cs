////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;

namespace FlaxEngine.GUI
{
    /// <summary>
    /// A panel that divides up available space between all of its children.
    /// </summary>
    /// <seealso cref="FlaxEngine.GUI.ContainerControl" />
    public class GridPanel : ContainerControl
    {
        private Margin _slotPadding;
        private float[] _cellsV;
        private float[] _cellsH;

        /// <summary>
        /// Gets or sets the padding given to each slot.
        /// </summary>
        public Margin SlotPadding
        {
            get => _slotPadding;
            set
            {
                _slotPadding = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// The cells widths in container width percentage (from left to right).
        /// </summary>
        public float[] RowFill
        {
            get => _cellsV;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _cellsV = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// The cells heights in container width percentage (from left to right).
        /// </summary>
        public float[] ColumnFill
        {
            get => _cellsH;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _cellsH = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridPanel"/> class.
        /// </summary>
        public GridPanel()
            : this(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridPanel"/> class.
        /// </summary>
        /// <param name="slotPadding">The slot padding.</param>
        public GridPanel(float slotPadding)
        {
            SlotPadding = new Margin(slotPadding);
            _cellsH = new[] { 0.5f, 0.5f };
            _cellsV = new[] { 0.5f, 0.5f };
        }

        /// <inheritdoc />
        protected override void PerformLayoutSelf()
        {
            base.PerformLayoutSelf();

            int i = 0;
            Vector2 upperLeft = Vector2.Zero;
            for (int rowIndex = 0; rowIndex < _cellsV.Length; rowIndex++)
            {
                upperLeft.X = 0;
                float cellHeight = _cellsV[rowIndex] * Height;
                for (int columnIndex = 0; columnIndex < _cellsH.Length; columnIndex++)
                {
                    if (i >= ChildrenCount)
                        break;

                    float cellWidth = _cellsH[columnIndex] * Width;

                    var slotBounds = new Rectangle(upperLeft, cellWidth, cellHeight);
                    _slotPadding.ShrinkRectangle(ref slotBounds);

                    var c = _children[i++];
                    c.Bounds = slotBounds;

                    upperLeft.X += cellWidth;
                }
                upperLeft.Y += cellHeight;
            }
        }
    }
}
