using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Tests{
    public class Pistal: GunBase{
        internal override void OnFire()
        {
            Debug.Log("OnFire() in Pistal");
        }

        internal override void OnReload()
        {
            Debug.Log(weaponSys.GetBulletCount(bullet.path));
            
                bulletCount = weaponSys.GetBulletCount(bullet.path) > 10 ? 10 : weaponSys.GetBulletCount(bullet.path);
                if (bulletCount < 0) bulletCount = 0;
                weaponSys.SetBulletCount(bullet.path, -bulletCount);
            
            
        }

        internal override void AfterFire()
        {
            Debug.Log("AfterFire() in Pistal");
        }
    }
}