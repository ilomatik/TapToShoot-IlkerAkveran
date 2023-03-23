using System.Collections.Generic;
using Events;
using Shootables;
using UnityEngine;

namespace Controllers
{
    public class WallSpawnController : MonoBehaviour
    {
        [SerializeField] private GameEvent onLevelComplete;
        [SerializeField] private List<GameObject> wallObjects;
        [SerializeField] private int row;
        [SerializeField] private int column;
        [SerializeField] private float gridSpacingOffset = 1.1f;
        [SerializeField] private Vector3 gridOrigin = Vector3.zero;

        //private List<GameObject> shootables = new List<GameObject>();
        private int shootableAmount;

        //TODO: set grid origin by number of rows and columns
        internal void SpawnCubeWall()
        {
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
                //shootables.Add(wallObj);
                shootableAmount++;
            }
            
            return wallObj;
        }

        public void DecreaseShootableWallObjectCount()
        {
            shootableAmount--;

            if (shootableAmount <= 0)
            {
                Debug.Log("Game over");
                onLevelComplete.Raise();
            }
        }
    }
}