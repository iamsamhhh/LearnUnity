using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Weapon{
public class BulletGo : MonoBehaviour
{
    internal Vector3 initVelocity;
    internal Vector3 pos;
    internal float initDamage;
    internal int numOfBullet;

    public void Set(Vector3 initVelocity, Vector3 pos, float initDamage, int numOfBullet){
        this.initDamage = initDamage;
        this.pos = pos;
        this.numOfBullet = numOfBullet;
        this.initVelocity = initVelocity;
    }
    
}
}