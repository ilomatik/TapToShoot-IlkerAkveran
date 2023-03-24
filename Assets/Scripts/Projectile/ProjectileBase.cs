using Events;
using Shootables;
using UnityEngine;

namespace Projectile
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        #region Variables

        public GameEvent onHitShootable;
        public GameObject hitParticle;
        public float movementSpeed;

        private Vector3 targetPosition;
        private Shootable targetObject;

        #endregion

        #region Unity Functions

        private void Update()
        {
            if (!gameObject.activeSelf) return;
            
            transform.Translate(Vector3.forward * (Time.deltaTime * movementSpeed));

            if (!(Vector3.Distance(transform.position, targetPosition) < 0.5f)) return;
            
            SetActive(false);
            targetObject.DestroyShootable();
            onHitShootable.Raise();
            OnHit();
        }

        #endregion

        #region Custom Functions

        public void SetTarget(Shootable target)
        {
            targetObject = target;
            targetPosition = target.transform.position;
            transform.LookAt(targetPosition);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        protected abstract void OnHit();

        #endregion
    }
}