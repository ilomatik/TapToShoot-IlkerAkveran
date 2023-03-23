using Controllers;
using Projectile;
using Shootables;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private Ray ray;
        private int touchCount = 0;

        private void Update()
        {
            if (!GameManager.isGameOn) return;
            if (!Input.GetMouseButtonDown(0)) return;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit)) return;
            if (!hit.transform.CompareTag("Shootable")) return;

            touchCount++;

            ProjectileBase bullet = touchCount % 2 == 0
                ? ProjectileSpawnController.GetBullet()
                : ProjectileSpawnController.GetBomb();

            bullet.transform.position = SpawnManager.Instance.projectileShootPosition.position;
            bullet.SetTarget(hit.transform.gameObject.GetComponent<Shootable>());
            bullet.SetActive(true);
        }
    }
}