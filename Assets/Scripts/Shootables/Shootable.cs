using DG.Tweening;
using Events;
using UnityEngine;

namespace Shootables
{
    public class Shootable : MonoBehaviour
    {
        public GameEvent onDestroyShootable;
        
        internal void DestroyShootable()
        {
            transform.DOScale(Vector3.zero, 10f).OnComplete(() =>
            {
                onDestroyShootable.Raise();
                Destroy(gameObject);
            });
        }
    }
}