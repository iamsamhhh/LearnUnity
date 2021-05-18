using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
public class WeaponSys : SingletonBase<WeaponSys>
{
    const int INVALID_NUM = -5;
    Dictionary<string, int>  bulletCountDict = new Dictionary<string, int>();
    
    public void Switch(GunBase gunType){
        GunSys.Instance.Switch(gunType);
    }

    public void Fire(){
        GunSys.Instance.Fire();
    }

    public bool SetBulletCount(string bulletType, int add){
        bool hasKey = bulletCountDict.ContainsKey(bulletType);
        if (hasKey){
            bulletCountDict[bulletType] += add;
        }
        else{
            bulletCountDict.Add(bulletType, add);
        }
        return hasKey;
    }

    public int  GetBulletCount(string bulletType){
        if (bulletCountDict.ContainsKey(bulletType)) return bulletCountDict[bulletType];
        else bulletCountDict.Add(bulletType, 0);
        
        return 0;
    }
    

}
}