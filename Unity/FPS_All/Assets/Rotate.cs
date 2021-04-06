using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        tran = transform;
    }

    // Update is called once per frame
    void Update()
    {
        tran.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
    }
}
