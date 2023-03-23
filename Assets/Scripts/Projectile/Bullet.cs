using UnityEngine;

namespace Projectile
{
    public class Bullet : ProjectileBase
    {
        public override void OnHit()
        {
            Debug.Log("Projectile Bullet OnHit is working");
            onHitShootable.Raise();
        }
    }
}