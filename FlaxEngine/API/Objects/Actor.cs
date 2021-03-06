////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Base class for all actor types on the scene
    /// </summary>
    public abstract partial class Actor : ITransformable
    {
        /// <summary>
        /// Returns true if object is fully static on the scene
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        public bool IsStatic
        {
#if UNIT_TEST_COMPILANT
			get; set;
#else
            get { return Internal_GetStaticFlags(unmanagedPtr) == StaticFlags.FullyStatic; }
#endif
        }

        /// <summary>
        /// The rotation as Euler angles in degrees.
        /// </summary>
        /// <remarks>
        /// The x, y, and z angles represent a rotation z degrees around the z axis, x degrees around the x axis, and y degrees
        /// around the y axis (in that order).
        /// Angles order (xyz): pitch, yaw and roll.
        /// </remarks>
        [UnmanagedCall]
        [HideInEditor]
        [NoSerialize]
        public Vector3 EulerAngles
        {
#if UNIT_TEST_COMPILANT
			get { return Orientation.EulerAngles; }
            set
            {
                Quaternion orientation;
                Quaternion.Euler(ref value, out orientation);
                Orientation = orientation;
            }
#else
            get { return Orientation.EulerAngles; }
            set
            {
                Quaternion orientation;
                Quaternion.Euler(ref value, out orientation);
                Internal_SetOrientation(unmanagedPtr, ref orientation);
            }
#endif
        }

        /// <summary>
        /// The local rotation as Euler angles in degrees.
        /// </summary>
        /// <remarks>
        /// The x, y, and z angles represent a rotation z degrees around the z axis, x degrees around the x axis, and y degrees
        /// around the y axis (in that order).
        /// Angles order (xyz): pitch, yaw and roll.
        /// </remarks>
        [UnmanagedCall]
        [HideInEditor]
        [NoSerialize]
        public Vector3 LocalEulerAngles
        {
#if UNIT_TEST_COMPILANT
			get { return LocalOrientation.EulerAngles; }
            set
            {
                Quaternion orientation;
                Quaternion.Euler(ref value, out orientation);
                LocalOrientation = orientation;
            }
#else
            get { return LocalOrientation.EulerAngles; }
            set
            {
                Quaternion orientation;
                Quaternion.Euler(ref value, out orientation);
                Internal_SetLocalOrientation(unmanagedPtr, ref orientation);
            }
#endif
        }

        /// <summary>
        /// Gets or sets the actor direction vector (aka forward direction).
        /// </summary>
        [HideInEditor]
        [NoSerialize]
        public Vector3 Direction
        {
            get => Vector3.ForwardLH * Orientation;
            set
            {
                Vector3 right = Vector3.Cross(value, Vector3.Up);
                Vector3 up = Vector3.Cross(right, value);
                //up = Vector3.Up;
                Orientation = Quaternion.LookRotation(value, up);
            }
        }

        /// <summary>
        /// Gets a list of all scripts attached to this object. It's read-only array. Use AddScript/RemoveScript to modify
        /// collection.
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        [EditorDisplay("Scripts", "__inline__")]
        [EditorOrder(-5)]
        [MemberCollection(ReadOnly = true, NotNullItems = true, CanReorderItems = false)]
        public Script[] Scripts
        {
#if UNIT_TEST_COMPILANT
			get; set;
#else
            get { return Internal_GetScripts(unmanagedPtr); }
            internal set { }
#endif
        }

        /// <summary>
        /// Returns true if actor has parent
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        [NoSerialize]
        public bool HasParent
        {
#if UNIT_TEST_COMPILANT
			get; set;
#else
            get { return Internal_GetParent(unmanagedPtr) != null; }
#endif
        }

        /// <summary>
        /// Returns true if actor has any children
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        [NoSerialize]
        public bool HasChildren
        {
#if UNIT_TEST_COMPILANT
			get; set;
#else
            get { return Internal_GetChildCount(unmanagedPtr) > 0; }
#endif
        }

        /// <summary>
        /// Resets actor local transform
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResetLocalTransform()
        {
            LocalTransform = Transform.Identity;
        }

        /// <summary>
        /// Creates new instance of the script and adds it to the actor.
        /// </summary>
        /// <typeparam name="T">The script type.</typeparam>
        /// <returns>Created script object.</returns>
        public T AddScript<T>() where T : Script
        {
            var script = New<T>();
            AddScript(script);
            return script;
        }

        /// <summary>
        /// Returns true if actor object has child actor with given name
        /// </summary>
        /// <param name="name">Actor name</param>
        /// <returns></returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public bool HasChild(string name)
        {
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChildWithName(unmanagedPtr, name) != null;
#endif
        }

        /// <summary>
        /// Sets actor parent to this object
        /// </summary>
        /// <param name="actor">Actor to link</param>
        /// <param name="worldPositionStays">Should actor world positions remain the same after parent change?</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void AddChild(Actor actor, bool worldPositionStays = true)
        {
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            actor?.SetParent(this);
#endif
        }

        /// <summary>
        /// Finds the child actor of the given type or creates a new one.
        /// </summary>
        /// <typeparam name="T">Type of the actor.</typeparam>
        /// <returns>The child actor.</returns>
        public T GetOrAddChild<T>() where T : Actor
        {
            var result = GetChild<T>();
            if (result == null)
            {
                result = New<T>();
                result.SetParent(this, false);
            }
            return result;
        }

        /// <summary>
        /// Determines if there is an intersection between the actor and a ray.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="distance">When the method completes and returns true, contains the distance of the intersection.</param>
        /// <returns>True if the actor is intersected by the ray, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
        public bool IntersectsItself(ref Ray ray, out float distance)
        {
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_IntersectsItself(unmanagedPtr, ref ray, out distance);
#endif
        }

        /// <summary>
        /// Serializes the actor objects to the raw bytes. Serialized are actor properties and scripts but no child actors.
        /// Serializes references to the other objects in a proper way using IDs.
        /// </summary>
        /// <param name="actors">The actors.</param>
        /// <returns>The bytes array with serialized actors data. Returns null if fails.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
        public static byte[] ToBytes(Actor[] actors)
        {
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_ToBytes(Array.ConvertAll(actors, GetUnmanagedPtr));
#endif
        }

        /// <summary>
        /// Deserializes the actor objects from the raw bytes. Deserialized are actor properties and scripts but no child actors.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="idsMapping">
        /// The serialized objects ids mapping table used to change object ids and keep valid reference
        /// links. Use null value to skipp ids mapping.
        /// </param>
        /// <returns>Spawned actors deserialized from the data. Returns null if fails.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
        public static Actor[] FromBytes(byte[] data, Dictionary<Guid, Guid> idsMapping = null)
        {
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Guid[] keys = idsMapping?.Keys.ToArray();
            Guid[] values = idsMapping?.Values.ToArray();
            return Internal_FromBytes(data, keys, values);
#endif
        }

        /// <summary>
        /// Destroys the children. Calls Object.Destroy on every child actor and unlink them for the parent.
        /// </summary>
        /// <param name="timeLeft">The time left to destroy object (in seconds).</param>
        public void DestroyChildren(float timeLeft = 0.0f)
        {
            Actor[] children = GetChildren();
            for (var i = 0; i < children.Length; i++)
            {
                children[i].Parent = null;
                Destroy(children[i], timeLeft);
            }
        }

        /// <inheritdoc />
        [UnmanagedCall]
        public override string ToString()
        {
            return $"{Name} ({GetType().Name})";
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script[] Internal_GetScripts(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_IntersectsItself(IntPtr obj, ref Ray ray, out float distance);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern byte[] Internal_ToBytes(IntPtr[] actors);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor[] Internal_FromBytes(byte[] data, Guid[] idsMappingKeys, Guid[] idsMappingValues);
    }
}
