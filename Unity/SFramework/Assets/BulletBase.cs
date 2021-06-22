using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Weapon{

public class BulletBase<T> : SFObject where T : BulletGo
{
    
    GameObject prefeb;
    float initDamage;
    int numOfBullet;

    public BulletBase(GameObject prefeb, float initDamage, int numOfBullet){
        this.initDamage = initDamage;
        this.numOfBullet = numOfBullet;
        this.prefeb = prefeb;
    }

    public GameObject Spawn(Vector3 initVelocity, Vector3 pos, float initDamage, int numOfBullet){
        var go = GameObject.Instantiate(prefeb, pos, Quaternion.identity);
        var b = go.AddComponent<T>();
        b.Set(initVelocity, pos, initDamage, numOfBullet);
        return go;
    }

}

}