using DG.Tweening;
using UnityEngine;

namespace Testers
{
    public class PickupCubeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _pickupCubePrefab;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;
        private void OnMouseDown()
        {
            SpawnPickupCube();
        }

        private void SpawnPickupCube()
        {
            var pickup = Instantiate(_pickupCubePrefab);
            pickup.transform.localPosition = transform.position;
            Vector3 translation = _target.position - transform.position;
            float moveDuration = translation.magnitude / _speed;
            Tween tween = pickup.transform.DOMove(_target.position, moveDuration);
            pickup.AddComponent<TweenRef>().Tween = tween;

        }
    }
}
