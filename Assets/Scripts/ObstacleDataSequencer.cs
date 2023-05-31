using UnityEngine;

public class ObstacleDataSequencer : MonoBehaviour
{
   [SerializeField] private ObstacleData[] _data;
   private System.Random rnd = new System.Random();

   public ObstacleData Next
   {
      get
      {
         int idx = rnd.Next(_data.Length);
         return _data[idx];
      }
   }
   
}
