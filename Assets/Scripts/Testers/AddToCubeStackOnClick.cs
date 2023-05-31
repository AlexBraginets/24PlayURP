using UnityEngine;

namespace Testers
{
    public class AddToCubeStackOnClick : MonoBehaviour
    {
        [SerializeField] private CubeStack _cubeStack;
        private void OnMouseDown()
        {
            AddToCubeStack();
        }

        private void AddToCubeStack()
        {
            _cubeStack.Add(gameObject);
        }
    }
}
