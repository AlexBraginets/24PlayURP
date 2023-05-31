using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _zOffset;

    private void Awake()
    {
        _zOffset = (transform.position - _target.position).z;
    }

    private void LateUpdate()
    {
        var position = transform.position;
        position.z = _target.position.z + _zOffset;
        transform.position = position;
    }
}