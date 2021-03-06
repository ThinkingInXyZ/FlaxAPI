////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;

namespace FlaxEngine.GUI
{
    /// <summary>
    /// Inteager value editor.
    /// </summary>
    /// <seealso cref="int" />
    public class IntValueBox : ValueBox<int>
    {
        /// <inheritdoc />
        public override int Value
        {
            get => _value;
            set
            {
                value = Mathf.Clamp(value, _min, _max);
                if (_value != value)
                {
                    // Set value
                    _value = value;

                    // Update
                    UpdateText();
                    OnValueChanged();
                }
            }
        }

        /// <inheritdoc />
        public override int MinValue
        {
            get => _min;
            set
            {
                if (_min != value)
                {
                    if(value > _max)
                        throw new ArgumentException();

                    _min = value;
                    Value = Value;
                }
            }
        }

        /// <inheritdoc />
        public override int MaxValue
        {
            get => _max;
            set
            {
                if (_max != value)
                {
                    if (value < _min)
                        throw new ArgumentException();

                    _max = value;
                    Value = Value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntValueBox"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="x">The x location.</param>
        /// <param name="y">The y location.</param>
        /// <param name="width">The width.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="slideSpeed">The slide speed.</param>
        public IntValueBox(int value, float x = 0, float y = 0, float width = 120, int min = int.MinValue, int max = int.MaxValue, float slideSpeed = 1)
            : base(Mathf.Clamp(value, min, max), x, y, width, min, max, slideSpeed)
        {
            UpdateText();
        }

        /// <summary>
        /// Sets the limits from the attribute.
        /// </summary>
        /// <param name="limits">The limits.</param>
        public void SetLimits(LimitAttribute limits)
        {
            _min = (int)limits.Min;
            _max = (int)Mathf.Max(_min, limits.Max);
            _slideSpeed = limits.SliderSpeed;
            Value = Value;
        }
        
        /// <inheritdoc />
        protected sealed override void UpdateText()
        {
            var text = _value.ToString();
            
            SetText(text);
        }

        /// <inheritdoc />
        protected override void TryGetValue()
        {
            // Try to parse int
            int value;
            if (int.TryParse(Text, out value))
            {
                // Set value
                Value = value;
            }
        }

        /// <inheritdoc />
        protected override void ApplySliding(float delta)
        {
            Value = _startSlideValue + (int)delta;
        }
    }
}
