using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

namespace SFramework.Tests{
public class NormalBullet : BulletBase
{
    internal override void OnFire(float a, float b, GameObject blt){
        Debug.Log("OnFire() in NormalBullet");
    }

    internal override void OnUpdate(){
        
        // Debug.Log("OnUpdate() in NormalBullet");
    }
}
}