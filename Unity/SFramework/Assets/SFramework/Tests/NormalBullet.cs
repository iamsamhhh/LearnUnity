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
            var temp = Instantiate(prefeb);
            temp.transform.position = gunTip.position;
            temp.GetComponent<BulletBase>().tran = gunTip;
            temp.SetActive(false);
            return temp;
        }

        void BulletResetMethod(GameObject go){
            go.transform.position = Vector3.zero;
            go.SetActive(false);
        }
        GameObject go = BulletSys.instance.Spawn(path, BulletFactoryMethod, BulletResetMethod);
        go.SetActive(true);
        return go;
    }

    
    

    internal override void OnUpdate(){
        if (tran == null) return;
        transform.Translate(transform.forward*Time.fixedDeltaTime * 10);
        if (Vector3.Distance(transform.position, tran.position) >= 10){
            BulletSys.instance.Recycle(path, gameObject);
        }
    }
}
}