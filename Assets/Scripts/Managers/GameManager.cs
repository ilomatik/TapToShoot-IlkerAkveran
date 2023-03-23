using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            SpawnManager.Instance.SpawnWall();
            SpawnManager.Instance.SpawnProjectilePools();
        }
    }
}