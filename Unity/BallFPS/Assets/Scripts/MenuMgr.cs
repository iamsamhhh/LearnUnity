using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFramework;

public class MenuMgr : MonoBehaviourSimplify
{
    Button startBut;
    // Start is called before the first frame update
    void Start()
    {
        startBut = GameObject.Find("Start").GetComponent<Button>();
        GUIManager
            .Instance
            .AddListenerWhenClicked(startBut, () =>
            {
                BroadcastEvent(EventType.StartButtonClicked);
            });
    }

}
