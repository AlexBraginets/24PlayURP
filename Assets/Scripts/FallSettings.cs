using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class FallSettings : ScriptableObject
{
    [SerializeField] private float gravity;


    public void Animate(Transform obj, int oldPosition, int newPosition, Vector3 offset)
    {
        float magnitude = .12f;
        float springDuration = .1f;
        offset += Vector3.down * magnitude;
        int dy = oldPosition - newPosition;
        float duration = GetMoveDuration(dy);
        Vector3 position = GetPosition(newPosition);
        var sequence = DOTween.Sequence();
        sequence.Append(obj.DOLocalMove(position + offset, duration));
        sequence.Append(obj.DOLocalMove(position + offset + Vector3.up * magnitude, springDuration));
        sequence.Play();
    }

    public void Animate(Transform obj, int oldPosition, int newPosition)
    {
        Animate(obj, oldPosition, newPosition, Vector3.zero);
    }

    private Vector3 GetPosition(int position)
    {
        return Vector3.up * position;
    }

    private float GetMoveDuration(int dy)
    {
        return Mathf.Sqrt(2 * dy / gravity);
    }
}