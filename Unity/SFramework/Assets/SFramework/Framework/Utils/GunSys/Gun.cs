using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public interface IGun
{
    void Fire();
}

public abstract class Gun : MonoBehaviour, IGun
{
    public Bullet bullet;
    public abstract void OnFire();
    public abstract void Reload();
    public abstract void OnInitBullet(Bullet bullet);
    public float fireRate, lastFireTime;
    protected int currentAmmo;
    public int maxBulletInMag;
    public Transform gunTip;

    protected virtual void Start()
    {
        currentAmmo = maxBulletInMag;
    }

    private void CreatBullet()
    {
        var tmp_bullet = Instantiate(bullet, gunTip.position, gunTip.rotation);
        OnInitBullet(tmp_bullet);
    }

    public void Fire()
    {
        if (!IsAllowShooting()) return;
        if (currentAmmo <= 0) { Reload(); return; }
        CreatBullet();
        OnFire();
        currentAmmo -= 1;
        lastFireTime = Time.time;
    }

    private bool IsAllowShooting()
    {
        return (lastFireTime + fireRate <= Time.time) && WeaponManager.Instance.allowShoot;
    }
}

public class WeaponManager : SingletonBase<WeaponManager>
{
    private Counter<Bullet> bulletCount = new Counter<Bullet>();
    public bool CountainsBullet(Bullet bullet)
    {
        return bulletCount.ContainsKey(bullet);
    }

    public void Set(Bullet bullet ,int count)
    {
        bulletCount.Set(bullet, count);
    }

    public bool TryGetBulletCount(Bullet bullet, out int count)
    {
        return bulletCount.TryGetValue(bullet, out count);
    }

    public void RemoveBullet(Bullet bullet)
    {
        bulletCount.Remove(bullet);
    }
    public bool allowShoot = true;
}



public class Counter<TKey>
{
    private Dictionary<TKey, int> dict;

    public Counter()
    {
        dict = new Dictionary<TKey, int>();
    }

    public void Set(TKey key, int value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = value;
        }
        else
        {
            dict.Add(key, value);
        }
    }

    public bool TryGetValue(TKey key, out int value)
    {
        if (dict.ContainsKey(key))
        {
            value = dict[key];
            return true;
        }
        value = 0;
        return false;
    }

    public bool ContainsKey(TKey key)
    {
        return dict.ContainsKey(key);
    }

    public void Remove(TKey key)
    {
        dict.Remove(key);
    }
}