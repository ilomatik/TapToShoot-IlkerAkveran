using UnityEngine;

namespace Projectile
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        public float movementSpeed;

        public abstract void OnHit();
    }
}