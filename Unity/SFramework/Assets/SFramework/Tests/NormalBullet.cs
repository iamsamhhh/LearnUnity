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

    internal override GameObject Spawn(Transform gunTip)
    {
        
        GameObject BulletFactoryMethod(){
            var temp = Instantiate(prefeb, gunTip.position, gunTip.rotation);
            temp.GetComponent<NormalBullet>().gunTip = gunTip;
            temp.SetActive(false);
            return temp;
        }

        void BulletResetMethod(GameObject go){
            go.SetActive(false);
        }
        GameObject go = BulletSys.instance.Spawn(path, BulletFactoryMethod, BulletResetMethod);
        go.transform.position = gunTip.position;
        go.transform.rotation = gunTip.rotation;
        go.SetActive(true);
        // Delay(5f, ()=>{BulletSys.instance.Recycle(path, gameObject);});
        return go;
    }

    
    

    internal override void OnUpdate(){
        if (gunTip == null) return;
        transform.Translate(transform.forward*Time.fixedDeltaTime * 10);
        if (Vector3.Distance(transform.position, gunTip.position) >= 10){
            BulletSys.instance.Recycle(path, gameObject);
        }
    }
}
}