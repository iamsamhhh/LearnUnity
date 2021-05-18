using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SFramework{
interface IBullet{
    GameObject Fire(Transform tran, float damage, float initForce);
}

public abstract class BulletBase: MonoBehaviour, IBullet
{

    
    
    public float damage;
    [SerializeField]
    public string path = "NormalBullet";
    private GameObject m_prefeb;
    internal GameObject prefeb{
        get{
            if(m_prefeb == null){
                m_prefeb = Resources.Load<GameObject>(path);
                Debug.LogError(m_prefeb);
            }
            return m_prefeb;
        }
    }
    internal abstract void OnFire(float damage, float initForce, GameObject go);

    internal GameObject Spawn(Transform tran){

        return Instantiate(prefeb, tran.position, tran.rotation);
    }


    public GameObject Fire(Transform tran, float damage, float initForce){
        GameObject bulletGo = Spawn(tran);
        OnFire(damage, initForce, bulletGo);
        return bulletGo;
    }

    internal abstract void OnUpdate();

    private void FixedUpdate() {
        OnUpdate();
    }
}
}