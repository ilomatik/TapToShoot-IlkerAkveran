using Controllers;
using Projectile;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private Ray ray;
        
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit)) return;
            if (hit.transform.CompareTag("Shootable"))
            {
                Debug.Log("InputManager Update ray hit Shootable");
                
                Bullet bullet = ProjectileSpawnController.GetBullet();
                bullet.transform.position = SpawnManager.Instance.projectileShootPosition.position;
                bullet.SetTarget(hit.transform.gameObject);
                bullet.SetActive(true);
            }
        }
    }
}