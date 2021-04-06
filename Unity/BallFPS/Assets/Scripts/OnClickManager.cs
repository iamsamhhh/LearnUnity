using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;
using UnityEngine.UI;

public class OnClickManager : MonoBehaviourSimplify
{
    private void Awake()
    {
        AddEvent(EventType.StartButtonClicked, StartButtonClicked);
    }
    private void OnDestroy()
    {
        RemoveEvent(EventType.StartButtonClicked, StartButtonClicked);
    }
    private void StartButtonClicked()
    {
        SceneMgr.Instance.LoadNextSceneWithOtherScene("GameUI");
    }

}
