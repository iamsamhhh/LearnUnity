using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class Move : MonoBehaviourSimplify
{
    private void Update() {
        transform.Translate(Vector3.one * 0.01f);
    }
}
