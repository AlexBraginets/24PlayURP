using UnityEngine;

namespace Testers
{
    public class CubeAnimatorTester : MonoBehaviour
    {
        [SerializeField] private int _newPosition;
        [SerializeField] private CubeAnimator _cubeAnimator;

        [ContextMenu("Animate")]
        private void Animate()
        {
            _cubeAnimator.Animate(_newPosition);
        }
    }
}
