using System.Collections.Generic;
using UnityEngine;

namespace Shootables
{
    public class ShootableColorController : MonoBehaviour
    {
        #region Variables

        public List<Color> shootableColors;

        private Material shootableMaterial;

        #endregion

        #region Unity Functions

        private void Awake()
        {
            shootableMaterial = GetComponent<MeshRenderer>().material;
            
            SetShootableColorRandom();
        }

        #endregion

        #region Custom Functions

        public void SetShootableColorRandom()
        {
            shootableMaterial.color = shootableColors[Random.Range(0, shootableColors.Count)];
        }

        #endregion
    }
}