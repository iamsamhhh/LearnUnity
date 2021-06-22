using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SFramework;

namespace SFramework.Weapon.Example{
public class WeaponController : MonoBehaviourSimplify
{
    TestGun testGun = new TestGun();
    // Start is called before the first frame update
    void Start()
    {
        testGun.LoadGun();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            BroadcastEvent("Fire");
        }
    }
}
}