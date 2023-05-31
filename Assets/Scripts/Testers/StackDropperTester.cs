using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Testers
{
    public class StackDropperTester : MonoBehaviour
    {
        [SerializeField] private CubeStack _cubeStack;
        [SerializeField] private StackDropper _stackDropper;
        [SerializeField] private List<int> _hitIndices;

        [ContextMenu("Drop")]
        private void Drop()
        {
            Drop(_hitIndices);
        }

        public void Drop(List<int> hitIndices)
        {
            RemoveCubes(hitIndices);
            _stackDropper.Drop(hitIndices);
        }

        private void RemoveCubes(List<int> hitIndices)
        {
            for (int i = 0; i < hitIndices.Count; i++)
            {
                int hitIndex = hitIndices[i];
                Transform cube = _cubeStack.Stack[hitIndex].transform;
                Vector3 position = cube.position;
                position += Vector3.forward * 3;
                float animationDuration = 2 / 7.5f;
                cube.DOMove(position, animationDuration);
                Destroy(cube.gameObject, 2f);
            }
        }
    }
}