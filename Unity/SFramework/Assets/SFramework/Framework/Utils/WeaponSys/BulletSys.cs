using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
    public class BulletSys : MonoSingletonBaseAuto<BulletSys>
    {
        Dictionary<string, SimpleObjectPool<GameObject>> m_bulletPools = new Dictionary<string, SimpleObjectPool<GameObject>>();
        [SerializeField]
        private int m_bulletCount{
            get{
                return WeaponSys.instance.GetBulletCount("NormalBullet");
            }
        }

        [SerializeField]
        private int bltCnt;

        public GameObject Spawn(string path, System.Func<GameObject> factoryMethod, System.Action<GameObject> resetMethod){
            if (!m_bulletPools.ContainsKey(path))
                m_bulletPools.Add(path, new SimpleObjectPool<GameObject>(factoryMethod, resetMethod, 5));
         
            return m_bulletPools[path].Allocate();
            
        }

        public void Recycle(string path, GameObject go){
            if (m_bulletPools.ContainsKey(path)){
                m_bulletPools[path].Recycle(go);
            }
        }
        private void Update() {
            bltCnt = m_bulletCount;
        }

    }
}