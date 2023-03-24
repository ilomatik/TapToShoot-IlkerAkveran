using DG.Tweening;
using Events;
using UnityEngine;

namespace Shootables
{
    public class Shootable : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameEvent onDestroyShootable;
        [SerializeField] private GameObject destroyParticle;

        #endregion

        #region Custom Functions

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
        
        #endregion
    }
}