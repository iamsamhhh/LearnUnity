using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class GameManager : MonoBehaviourSimplify
{
    private void Awake()
    {
        #region don't delet

        DontDestroyOnLoad(this);

        #endregion
        // AddEvent();
    }

    private void OnDestroy()
    {
        // RemoveEvent();
    }

    private void Update()
    {
        
        // BroadcastEvent();
    }

    
}
