////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;

namespace FlaxEngine.Rendering
{
    /// <summary>
    /// Material parameters types.
    /// </summary>
    public enum MaterialParameterType : byte
    {
        /// <summary>
        /// The invalid type.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// The bool.
        /// </summary>
        Bool,

        /// <summary>
        /// The inteager.
        /// </summary>
        Inteager,

        /// <summary>
        /// The float.
        /// </summary>
        Float,

        /// <summary>
        /// The vector2
        /// </summary>
        Vector2,

        /// <summary>
        /// The vector3.
        /// </summary>
        Vector3,

        /// <summary>
        /// The vector4.
        /// </summary>
        Vector4,

        /// <summary>
        /// The color.
        /// </summary>
        Color,

        /// <summary>
        /// The texture.
        /// </summary>
        Texture,

        /// <summary>
        /// The cube texture.
        /// </summary>
        CubeTexture,

        /// <summary>
        /// The normal map texture.
        /// </summary>
        NormalMap,

        /// <summary>
        /// The scene texture.
        /// </summary>
        SceneTexture,

        /// <summary>
        /// The render target (created from code).
        /// </summary>
        RenderTarget,
    }

    /// <summary>
    /// Material variable object. Allows to modify material parameter at runtime.
    /// </summary>
    public sealed class MaterialParameter
    {
        private int _hash;
        private MaterialBase _material;
        private int _index;
        private MaterialParameterType _type;
        private bool _isPublic;

        /// <summary>
        /// Gets the parent material.
        /// </summary>
        /// <value>
        /// The material.
        /// </value>
        public MaterialBase Material => _material;

        /// <summary>
        /// Gets the parameter type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public MaterialParameterType Type => _type;

        /// <summary>
        /// Gets a value indicating whether this parameter is public.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this parameter is public; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublic => _isPublic;

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            // If your game is using material parameter names a lot (lookups, searching by name, etc.) cache name in the constructor fo better performance
            get
            {
                // Validate the hash
                if (_hash != _material._parametersHash)
                    throw new InvalidOperationException("Cannot use invalid material parameter.");

                return MaterialBase.Internal_GetParamName(_material.unmanagedPtr, _index);
            }
        }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public unsafe object Value
        {
            get
            {
                // Validate the hash
                if (_material._parametersHash != _hash)
                    throw new InvalidOperationException("Cannot use invalid material parameter.");
                
                IntPtr ptr;
                bool vBool = false;
                int vInt = 0;
                float vFloat = 0;
                Vector2 vVector2 = new Vector2();
                Vector3 vVector3 = new Vector3();
                Vector4 vVector4 = new Vector4();
                Color vColor = new Color();
                Guid vGuid = new Guid();

                switch (_type)
                {
                    case MaterialParameterType.Bool:
                        ptr = new IntPtr(&vBool);
                        break;
                    case MaterialParameterType.Inteager:
                        ptr = new IntPtr(&vInt);
                        break;
                    case MaterialParameterType.Float:
                        ptr = new IntPtr(&vFloat);
                        break;
                    case MaterialParameterType.Vector2:
                        ptr = new IntPtr(&vVector2);
                        break;
                    case MaterialParameterType.Vector3:
                        ptr = new IntPtr(&vVector3);
                        break;
                    case MaterialParameterType.Vector4:
                        ptr = new IntPtr(&vVector4);
                        break;
                    case MaterialParameterType.Color:
                        ptr = new IntPtr(&vColor);
                        break;

                    case MaterialParameterType.CubeTexture:
                    case MaterialParameterType.Texture:
                    case MaterialParameterType.NormalMap:
                    case MaterialParameterType.RenderTarget:
                        ptr = new IntPtr(&vGuid);
                        break;

                    default: throw new ArgumentOutOfRangeException();
                }

                MaterialBase.Internal_GetParamValue(_material.unmanagedPtr, _index, ptr);

                switch (_type)
                {
                    case MaterialParameterType.Bool: return vBool;
                    case MaterialParameterType.Inteager: return vInt;
                    case MaterialParameterType.Float: return vFloat;
                    case MaterialParameterType.Vector2: return vVector2;
                    case MaterialParameterType.Vector3: return vVector3;
                    case MaterialParameterType.Vector4: return vVector4;
                    case MaterialParameterType.Color: return vColor;

                    case MaterialParameterType.CubeTexture:
                    case MaterialParameterType.Texture:
                    case MaterialParameterType.NormalMap: 
                    case MaterialParameterType.RenderTarget: return Object.Find<Object>(ref vGuid);

                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                // Validate the hash
                if (_material._parametersHash != _hash)
                    throw new InvalidOperationException("Cannot use invalid material parameter.");
                if (!_isPublic)
                    throw new InvalidOperationException("Cannot set private material parameters.");

                IntPtr ptr;
                bool vBool;
                int vInt;
                float vFloat;
                Vector2 vVector2;
                Vector3 vVector3;
                Vector4 vVector4;
                Color vColor;

                switch (_type)
                {
                    case MaterialParameterType.Bool:
                        vBool = (bool)value;
                        ptr = new IntPtr(&vBool);
                        break;
                    case MaterialParameterType.Inteager:
                    {
                        if (value is int)
                            vInt = (int)value;
                        else if (value is float)
                            vInt = (int)(float)value;
                        else
                            throw new InvalidCastException();
                        ptr = new IntPtr(&vInt);
                        break;
                    }
                    case MaterialParameterType.Float:
                    {
                        if (value is int)
                            vFloat = (int)value;
                        else if (value is float)
                            vFloat = (float)value;
                        else
                            throw new InvalidCastException();
                        ptr = new IntPtr(&vFloat);
                        break;
                    }
                    case MaterialParameterType.Vector2:
                        vVector2 = (Vector2)value;
                        ptr = new IntPtr(&vVector2);
                        break;
                    case MaterialParameterType.Vector3:
                        vVector3 = (Vector3)value;
                        ptr = new IntPtr(&vVector3);
                        break;
                    case MaterialParameterType.Vector4:
                        vVector4 = (Vector4)value;
                        ptr = new IntPtr(&vVector4);
                        break;
                    case MaterialParameterType.Color:
                        vColor = (Color)value;
                        ptr = new IntPtr(&vColor);
                        break;

                    case MaterialParameterType.CubeTexture:
                    case MaterialParameterType.Texture:
                    case MaterialParameterType.NormalMap:
                    case MaterialParameterType.RenderTarget:
                        ptr = Object.GetUnmanagedPtr(value as Object);
                        break;

                    default: throw new ArgumentOutOfRangeException();
                }

                MaterialBase.Internal_SetParamValue(_material.unmanagedPtr, _index, ptr);
            }
        }

        internal MaterialParameter(int hash, MaterialBase material, int index, MaterialParameterType type, bool isPublic)
        {
            _hash = hash;
            _material = material;
            _index = index;
            _type = type;
            _isPublic = isPublic;
        }
    }
}
