#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace SFramework
{
    public class MsgTestReciever : MonoBehaviourSimplify
    {
        private void Awake()
        {
            AddEvent<string>(EventType.ExampleType, LogSth);
        }

        private void OnDestroy()
        {
            RemoveEvent<string>(EventType.ExampleType, LogSth);
        }

        private void LogSth(string text)
        {
            Debug.Log("LogSth 被调用了");
            Debug.Log(text);
        }

#if UNITY_EDITOR
        [MenuItem("SFramework/12.消息系统/生成 Gameobj", false, 12)]
        private static void OnMenuClicked()
        {
            EditorApplication.isPlaying = true;

            var gameObj = new GameObject("MsgTestObj");
            gameObj.AddComponent<MsgTestReciever>();

            var gameObj2 = new GameObject("MsgTestObj2");
            gameObj2.AddComponent<MsgTestSender>();
        }
#endif
    }

}