using UnityEngine;

namespace Projectile
{
    public class Bomb : ProjectileBase
    {
        public override void OnHit()
        {
            Debug.Log("Projectile Bomb OnHit is working");
            onHitShootable.Raise();
        }
    }
}