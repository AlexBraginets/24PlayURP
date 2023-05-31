using DG.Tweening;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpDuration = .2f;
    [SerializeField] private FallSettings _fallSettings;
    private int _jumpHash;
    [SerializeField] private int _position = 1;
    private void Awake() => _jumpHash = Animator.StringToHash("Jump");

    public void Jump(int position)
    {
        _position = position;
        _animator.SetTrigger(_jumpHash);
        var pos = Vector3.up * position;
        transform.DOLocalMove(pos, _jumpDuration);
        // TextSpawner.Instance.Spawn("Jump");
    }

    public void JumpDown(int position)
    {
        _fallSettings.Animate(transform, _position, position);
        _position = position;
        // TextSpawner.Instance.Spawn($"JumpDown: {position}");
    }
}