using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class WeponConrtroller : MonoBehaviourSimplify
{
    public Gun equipedGun, initGun;
    Transform tran;
    bool fire;

    private void Start()
    {
        tran = transform;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (fire)
            {
                fire = false;
            }
            else
            {
                fire = true;
            }
        }
        if (fire) BroadcastEvent("fire");
    }

    public void EquipGun(Gun gun)
    {
        if (equipedGun != null)
        {
            Destroy(equipedGun.gameObject);
        }

        equipedGun = Instantiate(gun, tran.position, tran.rotation, tran);
    }

    public void PickUpGun(Gun gun)
    {
        if (equipedGun)
        {
            Destroy(equipedGun.gameObject);
        }
        WeaponManager.Instance.allowShoot = false;
        equipedGun = gun;
        StartCoroutine(Get());
    }

    void GoTo()
    {
        equipedGun.transform.position = Vector3.Lerp(equipedGun.transform.position, tran.transform.position, 0.1f);
        equipedGun.transform.rotation = Quaternion.Lerp(equipedGun.transform.rotation, tran.transform.rotation, 0.1f);
    }

    IEnumerator Get()
    {
        Debug.Log("IN");
        do
        {
            Debug.Log("hh");
            GoTo();
            yield return null;
        }
        while ((Vector3.Distance(equipedGun.transform.position, tran.position) > 0.01f) || (Quaternion.Angle(equipedGun.transform.rotation, tran.rotation) > 0.1f));
        Debug.Log("OUT");
        equipedGun.transform.position = tran.position;
        equipedGun.transform.rotation = tran.rotation;
        equipedGun.transform.parent = tran;
        WeaponManager.Instance.allowShoot = true;
    }
}