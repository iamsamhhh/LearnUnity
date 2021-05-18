using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    public class SingletonBase<T> where T : new()
    {
        private static T _instance;

        public static T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

    }

}