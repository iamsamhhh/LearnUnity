using UnityEngine;


namespace SFramework.Weapon.Example
{
    public class Bullets : SingletonBase<Bullets>
    {
        
        public BulletBase<B_556> _556 = new BulletBase<B_556>(Resources.Load<GameObject>("Sphere"), 10f, 1);
    }
}