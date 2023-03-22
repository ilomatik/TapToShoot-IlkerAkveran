using System.Collections.Generic;
using UnityEngine;

namespace Shootables
{
    public class ShootableColorController : MonoBehaviour
    {
        public List<Color> shootableColors;

        private Material shootableMaterial;

        private void Awake()
        {
            shootableMaterial = GetComponent<MeshRenderer>().material;
            
            SetShootableColorRandom();
        }

        public void SetShootableColorRandom()
        {
            shootableMaterial.color = shootableColors[Random.Range(0, shootableColors.Count - 1)];
        }
    }
}