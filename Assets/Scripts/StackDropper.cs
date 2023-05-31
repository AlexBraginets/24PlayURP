using System.Collections.Generic;
using Data;
using DG.Tweening;
using UnityEngine;

public class StackDropper : MonoBehaviour
{
    [SerializeField] private CubeStack _cubeStack;
    [SerializeField] private MovingStack _movingStack;
    [SerializeField] private StackAnimator _stackAnimator;
    [SerializeField] private PlayerAnimator _playerAnimator;
    private float _lastDropZ;
    [SerializeField] private TrackPositionTracker _trackPositionTracker;

    private void Drop(ObstacleHitMap hitMap)
    {
        if (Mathf.Abs(transform.position.z - _lastDropZ) < 2.1f) return;
        _lastDropZ = transform.position.z;
        var hitIndices = hitMap.GetHitIndices(transform.position.x, _trackPositionTracker);

        Drop(hitIndices);
    }

    public void Drop(List<int> hitIndices)
    {
        List<GameObject> stack = _cubeStack.Stack;
        for (int i = stack.Count - 1; i >= 0; i--)
        {
            if (hitIndices.Contains(i))
            {
                stack[i].transform.parent = null;
                stack.RemoveAt(i);
            }
        }

        DOVirtual.DelayedCall(GetAnimationDelay(), () =>
        {
            _stackAnimator.Animate();
            _playerAnimator.JumpDown(_cubeStack.Count);
        });
    }

    private float GetAnimationDelay() => 2f / _movingStack.Speed;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Tags.OBSTACLE)) return;
        var hitMap = other.GetComponent<ObstacleHitMap>();
        Drop(hitMap);
    }
}