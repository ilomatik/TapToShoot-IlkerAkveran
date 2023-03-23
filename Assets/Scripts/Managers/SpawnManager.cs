using Controllers;
using UnityEngine;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance;

        [SerializeField] private WallSpawnController wallSpawnController;
        [SerializeField] private ProjectileSpawnController projectileSpawnController;
        
        public Transform projectileShootPosition;

        private void Awake()
        {
            Instance = this;
        }

        public void SpawnWall()
        {
            wallSpawnController.SpawnCubeWall();
        }

        public void SpawnProjectilePools()
        {
            projectileSpawnController.SpawnBullet();
            projectileSpawnController.SpawnBomb();
        }
    }
}