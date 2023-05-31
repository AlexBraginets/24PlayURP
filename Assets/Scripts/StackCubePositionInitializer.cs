using UnityEngine;

public class StackCubePositionInitializer : MonoBehaviour
{
   private void Awake()
   {
      InitializePositions();
   }

   private void InitializePositions()
   {
      int childrenCount = transform.childCount;
      for (int i = 0; i < childrenCount; i++)
      {
         Transform child = transform.GetChild(i);
         CubeAnimator cubeAnimator = child.GetComponent<CubeAnimator>();
         cubeAnimator.position = i;
      }
   }
}
