using Events;
using UnityEngine;

namespace Projectile
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        public GameEvent onHitShootable;
        public float movementSpeed;

        private Vector3 targetPosition;
        private GameObject targetObject;
        
        private void Update()
        {
            if (gameObject.activeSelf)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

                if (Vector3.Distance(transform.position, targetPosition) < 0.25f)
                {
                    Debug.Log("Bullet too close to target");
                    OnHit();
                    SetActive(false);
                    Destroy(targetObject);
                }
            }
        }

        public void SetTarget(GameObject target)
        {
            targetObject = target;
            targetPosition = target.transform.position;
            transform.LookAt(targetPosition);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
        
        public abstract void OnHit();
    }
}