using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Pistal : Gun
{
    public List<Material> list;
    public override void OnFire()
    {

    }

    public override void OnInitBullet()
    {
        var bullet = Instantiate(this.bullet, gunTip.position, gunTip.rotation);
        bullet.met = list[Random.Range(0, list.Count)];
        var rb = bullet.GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = bullet.gameObject.AddComponent<Rigidbody>();
        }
        rb.AddForce(gunTip.forward * bullet.initSpeed * 5, ForceMode.Impulse);
    }

    public override void Reload()
    {
        
    }

    private void Start()
    {
        AddEvent("fire", Fire);
    }
    private void OnDestroy()
    {
        RemoveEvent("fire", Fire);
    }
}
