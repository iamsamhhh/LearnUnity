using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class GUIMgrTest : MonoBehaviourSimplify
{
    const string panelName = "Panel";
    private void Start() {
            
        GUIMgr.Instance.AddPanel(panelName, ELayer.Bottom);
        
        Delay(3, () => GUIMgr.Instance.RemovePanel(panelName) );
    }
}
