// Flax Engine scripting API

using System;

namespace FlaxEngine
{
    /// <summary>
    /// The RequireChildActor attribute automatically adds required child actor as dependencies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class RequireChildActorAttribute : Attribute
    {
        /// <summary>
        /// Type of the actor to require
        /// </summary>
        public Type Type;

        /// <summary>
        /// Require an child.
        /// </summary>
        /// <param name="requiredChild"></param>
        public RequireChildActorAttribute(Type requiredChild)
        {
            Type = requiredChild;
        }
    }
}
