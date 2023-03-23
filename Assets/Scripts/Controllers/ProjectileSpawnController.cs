using System.Collections.Generic;
using System.Linq;
using Projectile;
using UnityEngine;

namespace Controllers
{
    public class ProjectileSpawnController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int spawnAmount;
        [SerializeField] private Transform bulletParent;
        [SerializeField] private Transform bombParent;
        [SerializeField] private Bullet bulletObject;
        [SerializeField] private Bomb bombObject;

        private static List<Bullet> bulletPool = new List<Bullet>();
        private static List<Bomb> bombPool = new List<Bomb>();

        #endregion

        #region Custom Functions

        internal void SpawnBullet()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                Bullet spawnBullet = Instantiate(bulletObject, bulletParent);
                spawnBullet.gameObject.SetActive(false);
                bulletPool.Add(spawnBullet);
            }
        }

        internal void SpawnBomb()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                Bomb spawnBomb = Instantiate(bombObject, bombParent);
                spawnBomb.gameObject.SetActive(false);
                bombPool.Add(spawnBomb);
            }
        }

        public static ProjectileBase GetBullet()
        {
            return bulletPool
                .SelectMany(bullet => bulletPool.Where(bulletObject => !bulletObject.gameObject.activeInHierarchy))
                .FirstOrDefault();
        }

        public static ProjectileBase GetBomb()
        {
            return bombPool
                .SelectMany(bomb => bombPool.Where(bombObject => !bombObject.gameObject.activeInHierarchy))
                .FirstOrDefault();
        }

        #endregion
    }
}