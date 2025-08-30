using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class SerializedType
    {
        [SerializeField] private string _assemblyQualifiedName;

        public Type type
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyQualifiedName))
                    return null;
                return Type.GetType(_assemblyQualifiedName);
            }
        }

        public void Set(Type type)
        {
            _assemblyQualifiedName = type?.AssemblyQualifiedName;
        }
    }
}