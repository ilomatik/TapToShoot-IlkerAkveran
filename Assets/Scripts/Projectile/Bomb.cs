using Shootables;
using UnityEngine;

namespace Projectile
{
    public class Bomb : ProjectileBase
    {
        [SerializeField] private float explosionRange;
        [SerializeField] private float explosionPower;

        protected override void OnHit()
        {
            if (hitParticle != null)
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }

            Vector3 explosionPosition = transform.position;
            var colliders = Physics.OverlapSphere(explosionPosition, explosionRange);

            foreach (Collider col in colliders)
            {
                var rigidBody = col.GetComponent<Rigidbody>();
                var shootable = col.GetComponent<Shootable>();

                if (rigidBody != null && shootable != null)
                {
                    rigidBody.AddExplosionForce(explosionPower, explosionPosition, explosionRange);
                    shootable.DestroyShootable();
                }
            }
            
        }
    }
}