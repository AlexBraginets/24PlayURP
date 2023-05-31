using UnityEngine;

public class CubeAnimator : MonoBehaviour
{
    public int position;
    [SerializeField] private FallSettings _fallSettings;

    public void Animate(int position)
    {
        _fallSettings.Animate(transform, this.position, position, Vector3.up / 2f);
        this.position = position;
    }
}