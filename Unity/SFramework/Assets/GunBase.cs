using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Weapon{
public abstract class GunBase : SFObject
{
    public void LoadGun(){
        AddEvent("Fire", Fire);
        mOnLoadGun();
    }

    internal abstract void Fire();
    internal abstract void mOnLoadGun();
    internal abstract void mOnUnloadGun();


    public void OnUnloadGun(){
        RemoveEvent("Fire", Fire);
        mOnUnloadGun();
    }

}
}