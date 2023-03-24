using Controllers;
using Projectile;
using Shootables;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        private Ray ray;
        private int touchCount;
        
        #endregion

        #region Unity Functions

        private void Update()
        {
            if (!GameManager.IsGameOn) return;
            if (!Input.GetMouseButtonDown(0)) return;
            if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit)) return;
            if (!hit.transform.CompareTag("Shootable")) return;

            touchCount++;

            ProjectileBase bullet = touchCount % 2 == 0
                ? ProjectileSpawnController.GetBullet()
                : ProjectileSpawnController.GetBomb();

            bullet.transform.position = SpawnManager.Instance.projectileShootPosition.position;
            bullet.SetTarget(hit.transform.gameObject.GetComponent<Shootable>());
            bullet.SetActive(true);
        }

        #endregion
    }
}