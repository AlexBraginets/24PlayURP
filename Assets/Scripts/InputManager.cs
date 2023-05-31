using UnityEngine;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private bool _isUpdating = false;
    private Vector2 _lastMousePosition;
    private float _lastHorizontalInput;
    [SerializeField] private float sensetivity;
    public float HorizontalInput { get; private set; }

    private void Update()
    {
        float screenWidth = Screen.width;
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
            _lastHorizontalInput = HorizontalInput;
            _isUpdating = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isUpdating = false;
        }

        if (!_isUpdating) return;
        Vector2 mousePosition = Input.mousePosition;
        float dx = (mousePosition - _lastMousePosition).x;
        dx /= screenWidth;
        dx *= sensetivity;
        HorizontalInput = Mathf.Clamp(_lastHorizontalInput - dx, -2, 2);
    }
}