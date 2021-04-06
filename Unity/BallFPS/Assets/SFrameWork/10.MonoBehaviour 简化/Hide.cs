using UnityEngine;

namespace SFramework
{
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {

        public float GetInput(string axis)
        {
            if (axis == "x")
            {
                return Input.GetAxis("Horizontal");
            }
            else if (axis == "z")
            {
                return Input.GetAxis("Vertical");
            }
            else
            {
                return Input.GetAxis(axis);
            }
            
        }

        public void Show()
        {
            GameObjectSimplify.Show(gameObject);
        }

        public void Hide()
        {
            GameObjectSimplify.Hide(gameObject);
        }

        public void Identity()
        {
            TransformSimplify.Identity(transform);
        }
    }

    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {
            Hide();
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("SFramework/10.MonoBehaviour 简化", false, 11)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            var gameObj = new GameObject("Hide");
            gameObj.AddComponent<Hide>();
        }
#endif
    }
}