using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Weapon.Example{
[RequireComponent(typeof(Rigidbody))]
public class B_556 : BulletGo
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initVelocity, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}