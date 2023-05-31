using TMPro;
using UnityEngine;

namespace Testers
{
    public class InputManagerTester : MonoBehaviour
    {
        [SerializeField] private TMP_Text _horizontalInputLabel;
        [SerializeField] private InputManager _inputManager;

        private void LateUpdate()
        {
            _horizontalInputLabel.text = $"Horizontal Input: {_inputManager.HorizontalInput}";
        }
    }
}