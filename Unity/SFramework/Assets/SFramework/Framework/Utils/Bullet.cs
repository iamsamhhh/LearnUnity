using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float initSpeed;
    public float damage;

    protected virtual void Awake()
    {
        if (!WeaponManager.Instance.CountainsBullet(this))
        {
            Debug.Log(this);
            WeaponManager.Instance.Set(this, 0);
        }
    }
    
    public abstract void OnHit(Collision collision);

    protected virtual void OnCollisionEnter(Collision collision)
    {
        OnHit(collision);
    }

    protected virtual void OnDestroy()
    {
        WeaponManager.Instance.RemoveBullet(this);
    }
}
