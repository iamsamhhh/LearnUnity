using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponConrtroller : MonoBehaviour
{
    public Gun equipedGun;
    Transform tran;

    public void EquipGun(Gun gun)
    {
        if (equipedGun != null)
        {
            Destroy(equipedGun.gameObject);
        }

        equipedGun = Instantiate(gun, tran.position, tran.rotation, tran);
    }
}