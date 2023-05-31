using DG.Tweening;
using UnityEngine;

namespace Animators
{
    public class TrackPartAnimator : MonoBehaviour
    {
        [SerializeField] private float _animationDuration;

        public void Animate(TrackSpawnParams trackSpawnParams)
        {
            var spawnPosition = trackSpawnParams.SpawnPosition;
            var targetPosition = trackSpawnParams.TargetPosition;
            transform.position = spawnPosition;
            var position = targetPosition;
            position.y = transform.position.y;
            var seq = DOTween.Sequence();
            var tween = transform.DOMove(position, _animationDuration);
            seq.Append(tween);
            tween = transform.DOMove(targetPosition, .2f);
            seq.Append(tween);
            seq.Play();
        }
    }
}