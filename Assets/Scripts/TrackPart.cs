using Animators;
using DG.Tweening;
using UnityEngine;

public class TrackPart : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private TrackPartAnimator _animator;
    public bool Inactive => !gameObject.activeSelf;

    public void Initialize(ObstacleData obstacleData)
    {
        _obstacle.Init(obstacleData);
        gameObject.SetActive(true);
    }

    public void Spawn(TrackSpawnParams trackSpawnParams)
    {
        _animator.Animate(trackSpawnParams);
        DOVirtual.DelayedCall(20f, () => gameObject.SetActive(false));
    }
   
}