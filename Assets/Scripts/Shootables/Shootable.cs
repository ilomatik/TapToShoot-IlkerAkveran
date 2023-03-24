using DG.Tweening;
using Events;
using UnityEngine;

namespace Shootables
{
    public class Shootable : MonoBehaviour
    {
        public GameEvent onDestroyShootable;
        public GameObject destroyParticle;
        
        internal void DestroyShootable()
        {
            onDestroyShootable.Raise();
            transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
            {
                if (destroyParticle != null)
                {
                    Instantiate(destroyParticle, transform.position, Quaternion.identity);
                }
                
                Destroy(gameObject);
            });
        }
    }
}