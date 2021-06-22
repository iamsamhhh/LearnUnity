using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Weapon.Example{
public class TestGun : GunBase
{
    Transform tran;
    internal override void Fire(){
        Bullets.instance._556.Spawn(tran.forward*100, tran.position, 10, 1);
    }

    internal override void mOnLoadGun(){
        tran = GameObject.Find("Tip").transform;
    }


    internal override void mOnUnloadGun(){
        
    }
}
}