using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    public partial class MonoBehaviourSimplify
    {
        private void Awake()
        {
            var go = FindObjectOfType<GameManager>();
            if (go == null)
            {
                GameObject gO = new GameObject("Mgr");

                gO.AddComponent<GUIManager>();
                gO.AddComponent<AudioManager>();
                gO.AddComponent<SceneMgr>();
                gO.AddComponent<GameManager>();
                gO.AddComponent<OnClickManager>();
            }
        }
    }
}
