using Controllers;
using UnityEngine;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance;

        #region Variables

        [SerializeField] private WallSpawnController wallSpawnController;
        [SerializeField] private ProjectileSpawnController projectileSpawnController;
        
        public Transform projectileShootPosition;

        #endregion

        #region Unity Functions
        
        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region Custom Functions
        
        public void SpawnWall()
        {
            wallSpawnController.SpawnCubeWall();
        }

        public void SpawnProjectilePools()
        {
            projectileSpawnController.SpawnBullet();
            projectileSpawnController.SpawnBomb();
        }

        #endregion
    }
}