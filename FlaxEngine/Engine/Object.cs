// Flax Engine scripting API

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Base class for all objects Flax can reference.
    /// </summary>
    public abstract class Object
    {
        [NonSerialized]
        internal IntPtr unmanagedPtr = IntPtr.Zero;

        [NonSerialized]
        internal Guid id = Guid.Empty;

        /// <summary>
        /// Gets unique object ID
        /// </summary>
        [UnmanagedCall]
        public Guid ID
        {
            get { return id; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Object"/>.
        /// Always called from C++.
        /// </summary>
        protected Object()
        {
        }
        
        /// <summary>
        /// Notifies the unmanaged interop object that the managed instance was finalized.
        /// </summary>
        ~Object()
        {
            if (unmanagedPtr != IntPtr.Zero)
            {
                Internal_ManagedInstanceDeleted(unmanagedPtr);
            }
        }

        /// <summary>
        /// Destroys the specified object.
        /// The object obj will be destroyed now or ather the time specified in seconds from now.
        /// If obj is a Script it will remove the component from the Actor and destroy it.
        /// If obj is a Actor it will remove it from the Scene and destroy it and all its Scripts and all children of the Actor.
        /// Actual object destruction is always delayed until after the current Update loop, but will always be done before rendering.
        /// </summary>
        /// <param name="obj">The object to destroy.</param>
        /// <param name="timeLeft">The time left to destroy object (in seconds).</param>
        public static void Destroy(Object obj, float timeLeft = 0.0f)
        {
            Internal_Destroy(GetUnmanagedPtr(obj), timeLeft);
        }
        
        /// <summary>
        /// Check if object exists
        /// </summary>
        /// <param name="obj">Object to check</param>
        public static implicit operator bool(Object obj)
        {
            return obj != null && obj.unmanagedPtr != IntPtr.Zero;
        }

        internal static IntPtr GetUnmanagedPtr(Object obj)
        {
            return obj != null ? obj.unmanagedPtr : IntPtr.Zero;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return unmanagedPtr.GetHashCode();
        }

        #region Internal Calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_ManagedInstanceDeleted(IntPtr nativeInstance);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Destroy(IntPtr obj, float timeLeft);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Object Internal_FindObject(ref Guid id);

        #endregion
    }
}
