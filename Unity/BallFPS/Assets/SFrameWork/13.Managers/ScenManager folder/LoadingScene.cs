using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SFramework;
using UnityEngine;

public class LoadingScene : MonoBehaviourSimplify
{
    [SerializeField]
    Text text;
    [SerializeField]
    Slider slider;
    private SceneMgr sceneMgr;
    private void Start()
    {
        sceneMgr = SceneMgr.GetInstance();


        if (sceneMgr.addedSceneIndex != 0)
        {
            sceneMgr.StartLoadingScene(sceneMgr.LoadSceneCoroutine(sceneMgr.sceneIndexNeedToLoad, slider, text, sceneMgr.addedSceneIndex));
        }
        else if (sceneMgr.addedSceneName != null)
        {
            sceneMgr.StartLoadingScene(sceneMgr.LoadSceneCoroutine(sceneMgr.sceneIndexNeedToLoad, slider, text, sceneMgr.addedSceneName));
        }
        else
        {
            if (sceneMgr.sceneIndexNeedToLoad == 0)
            {
                sceneMgr.StartLoadingScene(sceneMgr.LoadSceneCoroutine(sceneMgr.sceneIndexNeedToLoad++, slider, text));
            }
            else
            {
                sceneMgr.StartLoadingScene(sceneMgr.LoadSceneCoroutine(sceneMgr.sceneIndexNeedToLoad, slider, text));
            }
        }
        
        
    }


}
