using UnityEngine;

namespace Testers
{
    public class StackCubeSelector : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private Color defaultColor;
        [SerializeField] private Color selectedColor;

        private void Awake()
        {
            defaultColor = _meshRenderer.material.color;
        }

        public void Select()
        {
            SetColor(selectedColor);
        }

        public void Deselect()
        {
            SetColor(defaultColor);
        }

        private void SetColor(Color color) => _meshRenderer.material.color = color;
    }
}