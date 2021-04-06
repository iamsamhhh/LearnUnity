using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : Bullet
{

    public TrailRenderer tr;
    public MeshRenderer mr;
    public override void OnAwake()
    {
        mr = GetComponent<MeshRenderer>();
        tr = GetComponent<TrailRenderer>();
        if (mr && tr && met)
        {
            mr.material = met;
            tr.material = met;
            return;
        }
        Invoke(nameof(color), 0);
    }
    private void Update()
    {
        //if (Random.Range(0, 50) == 6)
        //{
        //    var rb = gameObject.GetComponent<Rigidbody>();
        //    rb.isKinematic = true;
        //}
    }

    void color()
    {
        if (mr && tr && met)
        {
            mr.material = met;
            tr.material = met;
            return;
        }
        Invoke(nameof(color), 0);
    }
    public override void OnHit(Collision collision)
    {
        
    }
}
