#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace SFramework
{
    public partial class GameObjectSimplify
    {
        public static void Show(GameObject gameObj)
        {
            gameObj.SetActive(true);
        }

        public static void Hide(GameObject gameObj)
        {
            gameObj.SetActive(false);
        }

#if UNITY_EDITOR
        [MenuItem("SFramework/7.GameObejct API 简化/显示、隐藏简化", false, 8)]
#endif
        private static void MenuClicked()
        {
            var gameObject = new GameObject();

            Hide(gameObject);
        }
    }
}