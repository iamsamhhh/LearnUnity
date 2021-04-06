using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float initSpeed, damage;
    public Material met;
    public string type;

    protected virtual void Awake()
    {
        if (!WeaponManager.Instance.CountainsBullet(type))
        {
            WeaponManager.Instance.Set(type, 0);
        }
        OnAwake();
    }
    public abstract void OnAwake();
    public abstract void OnHit(Collision collision);

    protected virtual void OnCollisionEnter(Collision collision)
    {
        OnHit(collision);
    }

    protected virtual void OnDestroy()
    {
        WeaponManager.Instance.RemoveBullet(type);
    }
}
