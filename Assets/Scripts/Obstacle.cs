using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
   [SerializeField] private ObstacleData _data;
   [SerializeField] private GameObject _wallCubePrefab;
   [SerializeField] private List<GameObject> _wallCubes = new List<GameObject>();
   [SerializeField] private ObstacleHitMap _obstacleHitMap;
   [ContextMenu("Init")]
   private void Init()
   {
      Init(_data);
   }
   private GameObject GetWallCube()
   {
      return Instantiate(_wallCubePrefab);
   }
   public void Init(ObstacleData data)
   {
      Dispose();
      _data = data;
      _obstacleHitMap.hitMap = data.data;
      float xPosition = 2f;
      float yPosition;
      foreach (var hitIndices in data.data.hitIndices)
      {
         foreach (var hitIndex in hitIndices.hitIndices)
         {
            yPosition = hitIndex;
            var wallCube = GetWallCube();
            wallCube.transform.parent = transform;
            wallCube.transform.localPosition = new Vector3(xPosition, yPosition, 0f);
            _wallCubes.Add(wallCube);
         }

         xPosition--;
      }
   }

   public void Dispose()
   {
      foreach (var wallCube in _wallCubes)
      {
         Destroy(wallCube);
      }
   }
}