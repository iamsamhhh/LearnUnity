using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SFramework
{
    public partial class TransformSimplify
    {

#if UNITY_EDITOR

        [MenuItem("SFramework/5.Transform API 简化/1.赋值优化", false, 5)]
        private static void MenuClicked1()
        {
            var transform = new GameObject("transform").transform;

            SetLocalPosX(transform, 5.0f);
            SetLocalPosY(transform, 5.0f);
            SetLocalPosZ(transform, 5.0f);
        }

        [MenuItem("SFramework/5.Transform API 简化/2.重置", false, 6)]
        private static void MenuClicked2()
        {
            var transform = new GameObject("transform").transform;

            Identity(transform);
        }

#endif
        /// <summary>
        /// 重置操作
        /// </summary>
        /// <param name="trans">Trans.</param>
        public static void Identity(Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localScale = Vector3.one;
            trans.localRotation = Quaternion.identity;
        }


        public static void SetLocalPosX(Transform transform, float x)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            transform.localPosition = localPos;
        }


        public static void SetLocalPosY(Transform transform, float y)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            transform.localPosition = localPos;
        }


        public static void SetLocalPosZ(Transform transform, float z)
        {
            var localPos = transform.localPosition;
            localPos.z = z;
            transform.localPosition = localPos;
        }


        public static void SetLocalPosXY(Transform transform, float x, float y)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            transform.localPosition = localPos;
        }


        public static void SetLocalPosXZ(Transform transform, float x, float z)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.z = z;
            transform.localPosition = localPos;
        }


        public static void SetLocalPosYZ(Transform transform, float y, float z)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetParent(Transform trans, Transform parentTrans)
        {
            trans.SetParent(parentTrans);
        }

    }

    

}