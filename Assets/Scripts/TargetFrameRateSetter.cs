using UnityEngine;

public class TargetFrameRateSetter : MonoBehaviour
{
    [SerializeField] private int frameRate;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }
}
