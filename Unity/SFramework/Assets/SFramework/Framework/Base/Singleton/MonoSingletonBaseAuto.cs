using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    public class MonoSingletonBaseAuto<T> : MonoBehaviourSimplify where T : MonoBehaviourSimplify
    {
        private static T _instance;

        public static T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }
    }
}