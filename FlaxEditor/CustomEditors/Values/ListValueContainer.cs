////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;

namespace FlaxEditor.CustomEditors
{
    /// <summary>
    /// Custom <see cref="ValueContainer"/> for <see cref="IList"/> (used for <see cref="Array"/> and <see cref="System.Collections.Generic.List{T}"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.CustomEditors.ValueContainer" />
    public sealed class ListValueContainer : ValueContainer
    {
        /// <summary>
        /// The index in the collection.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListValueContainer"/> class.
        /// </summary>
        /// <param name="elementType">Type of the collection elements.</param>
        /// <param name="index">The index.</param>
        public ListValueContainer(Type elementType, int index)
            : base(null, elementType)
        {
            Index = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListValueContainer"/> class.
        /// </summary>
        /// <param name="elementType">Type of the collection elements.</param>
        /// <param name="index">The index.</param>
        /// <param name="values">The collection values.</param>
        public ListValueContainer(Type elementType, int index, ValueContainer values)
            : this(elementType, index)
        {
            Capacity = values.Count;
            for (int i = 0; i < values.Count; i++)
            {
                var v = (IList)values[i];
                Add(v[index]);
            }
        }

        /// <inheritdoc />
        public override void Refresh(ValueContainer instanceValues)
        {
            if (instanceValues == null || instanceValues.Count != Count)
                throw new ArgumentException();

            for (int i = 0; i < Count; i++)
            {
                var v = (IList)instanceValues[i];
                this[i] = v[Index];
            }
        }

        /// <inheritdoc />
        public override void Set(ValueContainer instanceValues, object value)
        {
            if (instanceValues == null || instanceValues.Count != Count)
                throw new ArgumentException();

            for (int i = 0; i < Count; i++)
            {
                var v = (IList)instanceValues[i];
                v[Index] = value;
                this[i] = value;
            }
        }

        /// <inheritdoc />
        public override void Set(ValueContainer instanceValues)
        {
            if (instanceValues == null || instanceValues.Count != Count)
                throw new ArgumentException();

            for (int i = 0; i < Count; i++)
            {
                var v = (IList)instanceValues[i];
                v[Index] = this[i];
            }
        }
    }
}
