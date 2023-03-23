using UnityEngine;

namespace Projectile
{
    public class Bullet : ProjectileBase
    {
        protected override void OnHit()
        {
            if (hitParticle != null)
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
        }
    }
}