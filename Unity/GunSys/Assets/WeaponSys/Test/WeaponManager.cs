using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Tests{
public class WeaponManager : MonoBehaviour
{
    GunBase gun;
    BulletBase bullet;
    
    private void Awake() {
        gun = GameObject.Find("Pistal").GetComponent<GunBase>();
        // bullet = GameObject.Find("NormalBullet").GetComponent<BulletBase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        WeaponSys.Instance.SetBulletCount("NormalBullet", 20);
        WeaponSys.Instance.Switch(gun);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("into GetMouseButton(0)");
            WeaponSys.Instance.Fire();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            gun.Reload();
        }
    }
}
}