using System;
using System.Collections.Generic;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SFramework
{
    public class MsgTestSender : MonoBehaviourSimplify
    {
        private void Start()
        {
            Delay(1, Log);
            Delay(3, () => { EditorApplication.isPlaying = false; });
        }

        private void Log()
        {
            BroadcastEvent(EventType.ExampleType, "Hello");
        }
    }
}