using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
interface IGun{
    void Fire();
}

public abstract class GunBase : MonoBehaviourSimplify, IGun
{
    [SerializeField]
    internal Transform gunTip;
    [SerializeField]
    internal BulletBase bullet;
    internal WeaponSys weaponSys = WeaponSys.instance;
    [SerializeField]
    internal int maxBulletInGun;
    [SerializeField]
    internal int bulletCount;
    [SerializeField]
    internal float reloadInterval;
    [SerializeField]
    internal float fireInterval;
    [SerializeField]
    internal bool reloading;
    [SerializeField]
    internal bool canFire = true;
    


    internal abstract void OnFire();
    internal abstract void AfterFire();
    internal abstract void OnReload();

    public void Reload(){
        OnReload();
        reloading = true;
        Delay(reloadInterval, ()=>{reloading = false;});
    }

    public void Fire(){
        if (!canFire) return;

        if (!reloading){
            if (!noAmmo()){
                OnFire();
                bullet.Fire(gunTip, 20.0f, 200.0f);
                canFire = false;
                bulletCount--;
                Delay(fireInterval, ()=>{canFire = true;AfterFire();});
            }
            else{
                Debug.Log("Don't have enough ammo!!!");
                Reload();
                
            }
        }
        

        
    }

    internal bool noAmmo(){
        if (bulletCount < 0){
            Debug.LogError(bullet.path);
            Debug.LogError("Bullet count is lower than 0!");
            Debug.LogError(bulletCount);
        }
        return bulletCount <= 0;
    }

}
}