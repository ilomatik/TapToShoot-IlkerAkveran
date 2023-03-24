using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject levelCompletePanel;

        #endregion

        #region Custom Functions

        public void OnLevelComplete()
        {
            levelCompletePanel.SetActive(true);
        }

        #endregion
    }
}