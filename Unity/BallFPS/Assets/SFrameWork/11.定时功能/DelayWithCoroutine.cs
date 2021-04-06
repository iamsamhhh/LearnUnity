using System;
using System.Collections;
using UnityEngine;

namespace SFramework
{
    public partial class MonoBehaviourSimplify
    {
        public void Delay(float seconds, Callback onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }

        private static IEnumerator DelayCoroutine(float seconds, Callback onFinished)
        {
            yield return new WaitForSeconds(seconds);

            onFinished();
        }
    }

    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
        private void Start()
        {
            Delay(5.0f, () =>{ UnityEditor.EditorApplication.isPlaying = false; } );
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("SFramework/11.定时功能", false, 11)]
        private static void MenuClickd()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("DelayWithCoroutine")
                .AddComponent<DelayWithCoroutine>();
        }
#endif
    }
}