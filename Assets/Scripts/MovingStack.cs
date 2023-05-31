using UnityEngine;

public class MovingStack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _moveDelay;
    [SerializeField] private InputManager _inputManager;
    public float Speed => Mathf.Abs(_speed);

    private void Update()
    {
        if (Time.time < _moveDelay) return;
        var pos = transform.position + Vector3.forward * (_speed * Time.deltaTime);
        pos.x = _inputManager.HorizontalInput;
        transform.position = pos;
    }
}