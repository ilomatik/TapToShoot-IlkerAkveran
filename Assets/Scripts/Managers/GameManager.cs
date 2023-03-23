using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int targetFrame = 30;

        public static bool isGameOn;
        
        private void Start()
        {
            Application.targetFrameRate = targetFrame;
            SpawnManager.Instance.SpawnWall();
            SpawnManager.Instance.SpawnProjectilePools();
            isGameOn = true;
        }

        public void FinishGame()
        {
            isGameOn = false;
        }
    }
}