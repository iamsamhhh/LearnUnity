using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class GUIMgrTest : MonoBehaviourSimplify
{
    const string panelName = "Panel";
    private void Awake() {
        OnStart(()=>{
            GUIMgr.Instance.Set(new Vector2(3840, 2160), 1);
            GUIMgr.Instance.AddPanel(panelName, ELayer.Bottom);
            GUIMgr.Instance.OnClick(panelName, "Button", () => GUIMgr.Instance.RemovePanel(panelName) );
        });
    }

    private void OnDestroy() {
        GUIMgr.Instance.RemovePanel(panelName);
    }
}
