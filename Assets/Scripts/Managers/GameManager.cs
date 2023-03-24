using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int targetFrame = 30;

        public static bool IsGameOn;

        #endregion

        #region Unity Functions

        private void Start()
        {
            Application.targetFrameRate = targetFrame;
            SpawnManager.Instance.SpawnWall();
            SpawnManager.Instance.SpawnProjectilePools();
            IsGameOn = true;
        }

        #endregion

        #region Custom Functions

        public void FinishGame()
        {
            IsGameOn = false;
        }

        #endregion
    }
}