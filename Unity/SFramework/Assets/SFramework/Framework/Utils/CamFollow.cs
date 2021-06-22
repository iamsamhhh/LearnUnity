using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    Transform targetTran;
    [SerializeField]
    Vector3 offset;
    void LateUpdate()
    {
        transform.position = targetTran.position + offset;
    }
}
