#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;


namespace SFramework
{
    public partial class TransformSimplify
    {
        public static void AddChild(Transform transform, Transform childTrans)
        {
            childTrans.SetParent(transform);
        }
    }

    public partial class GameObjectSimplify
    {
        public static void Show(Transform transform)
        {
            transform.gameObject.SetActive(true);
        }

        public static void Hide(Transform transform)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public class PartialKeyword
    {
#if UNITY_EDITOR
        [MenuItem("SFramework/8.partial 关键字", false, 9)]
#endif
        private static void MenuClicked()
        {
            var parentTrans = new GameObject("Parent").transform;
            var childTrans = new GameObject("Child").transform;

            TransformSimplify.AddChild(parentTrans, childTrans);
            GameObjectSimplify.Hide(childTrans);

        }
    }
}