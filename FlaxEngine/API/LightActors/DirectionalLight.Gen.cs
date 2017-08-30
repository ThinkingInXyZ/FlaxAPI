////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
	/// <summary>
	/// Directional light emmits light from direction in space.
	/// </summary>
	[Serializable]
	public sealed partial class DirectionalLight : LightActor
	{
		/// <summary>
		/// Creates new <see cref="DirectionalLight"/> object.
		/// </summary>
		private DirectionalLight() : base()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="DirectionalLight"/> object.
		/// </summary>
		/// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static DirectionalLight New() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Create(typeof(DirectionalLight)) as DirectionalLight;
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
#endif
#endregion
	}
}
