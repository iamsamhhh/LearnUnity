using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class PlayerLook : MonoBehaviourSimplify
{
    public float mouseSensitivity;

    Vector3 rot;

    [SerializeField]
    private Vector2 min_maxValue;

    [SerializeField]
    private Vector3 offset;

    private Transform headTrans;


    private void Start()
    {
        headTrans = transform;
        
    }

    void Update()
    {
        headTrans.position = PlayerMovement.instance.transform.position + offset;
        var tmp_rotX = GetInput("Mouse Y") * mouseSensitivity;
        var tmp_rotY = GetInput("Mouse X") * mouseSensitivity;
        rot.x -= tmp_rotX;
        rot.y += tmp_rotY;

        rot.x = Mathf.Clamp(rot.x, min_maxValue.x, min_maxValue.y);

        headTrans.rotation = Quaternion.Euler(rot.x, rot.y, 0);
        PlayerMovement.instance.pointTrans.rotation = Quaternion.Euler(0, rot.y, 0);
    }
}
