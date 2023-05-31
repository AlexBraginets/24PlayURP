using System.Collections.Generic;
using UnityEngine;

namespace Testers
{
    public class StackDropperCubeSelector : MonoBehaviour
    {
        public List<int> HitIndices = new List<int>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryToggleHitIndex();
            }
        }

        private void TryToggleHitIndex()
        {
            if (GetCubeAnimator(out CubeAnimator cubeAnimator))
            {
                ToggleHitIndex(cubeAnimator);
            }
        }

        private void ToggleHitIndex(CubeAnimator cubeAnimator)
        {
            int hitIndex = cubeAnimator.position;
            if (HitIndices.Contains(hitIndex))
            {
                HitIndices.Remove(hitIndex);
                cubeAnimator.GetComponent<StackCubeSelector>().Deselect();
            }
            else
            {
                HitIndices.Add(hitIndex);
                cubeAnimator.GetComponent<StackCubeSelector>().Select();
            }
        }

        private bool GetCubeAnimator(out CubeAnimator cubeAnimator)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out cubeAnimator)) return true;
                Debug.Log("No cube animator found", hit.transform);
            }
            
            cubeAnimator = null;
            return false;
        }
    }
}