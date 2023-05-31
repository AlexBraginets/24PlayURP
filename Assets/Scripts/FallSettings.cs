using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class FallSettings : ScriptableObject
{
    [SerializeField] private float gravity;


    public void Animate(Transform obj, int oldPosition, int newPosition, Vector3 offset)
    {
        int dy = oldPosition - newPosition;
        float duration = GetMoveDuration(dy);
        Vector3 position = GetPosition(newPosition);
        obj.DOLocalMove(position + offset, duration);
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