using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompletePanel;

        public void OnLevelComplete()
        {
            levelCompletePanel.SetActive(true);
        }
    }
}