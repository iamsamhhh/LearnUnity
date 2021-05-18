using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
public class GunSys: SingletonBase<GunSys>
{
    GunBase currentGun;

    public void Switch(GunBase gun){
        if (gun == null)
            return;
        Debug.Log("switch succesfully");
        currentGun = gun;
    }

    public void Fire(){
        if (currentGun == null)
            return;
        currentGun.Fire();
    }
}
}