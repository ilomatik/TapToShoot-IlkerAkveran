using System.Collections.Generic;
using Events;
using Shootables;
using UnityEngine;

namespace Controllers
{
    public class WallSpawnController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameEvent onLevelComplete;
        [SerializeField] private List<GameObject> wallObjects;
        [SerializeField] private int row;
        [SerializeField] private int column;
        [SerializeField] private float gridSpacingOffset = 1.1f;
        [SerializeField] private Vector3 gridOrigin;

        private int shootableAmount;

        #endregion

        #region Custom Functions
        
        //TODO: set grid origin by number of rows and columns
        internal void SpawnCubeWall()
        {
            gridOrigin = new Vector3(-0.4f * row, -0.4f * column, 0f);
            
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < column; j++)
                {
                    Vector3 spawnPosition = new Vector3(i * gridSpacingOffset, j * gridSpacingOffset, 0) + gridOrigin;
                    Instantiate(PickRandomObject(), spawnPosition, Quaternion.identity, transform);
                }
            }
        }

        private GameObject PickRandomObject()
        {
            GameObject wallObj = wallObjects[Random.Range(0, wallObjects.Count)];

            if (wallObj.GetComponent<Shootable>())
            {
                shootableAmount++;
            }
            
            return wallObj;
        }

        public void DecreaseShootableWallObjectCount()
        {
            shootableAmount--;

            if (shootableAmount <= 0)
            {
                onLevelComplete.Raise();
            }
        }

        #endregion
    }
}