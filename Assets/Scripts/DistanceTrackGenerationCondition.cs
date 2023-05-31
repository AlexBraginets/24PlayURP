using UnityEngine;

public class DistanceTrackGenerationCondition : TrackGenerationCondition
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 _lastTrackPosition;

    private void Update()
    {
        if ((player.position - _lastTrackPosition).magnitude > 60) return;
        GenerateTrack();
    }

    private void GenerateTrack()
    {
        var spawnPosition = player.transform.position + Vector3.down * 10f;
        var targetPosition = _lastTrackPosition;
        GenerateTrack(new TrackSpawnParams()
        {
            SpawnPosition = spawnPosition,
            TargetPosition = targetPosition
        });
        _lastTrackPosition += Vector3.back * 30f;
    }
}