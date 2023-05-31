using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private TrackGenerationCondition _trackGenerationCondition;
    [SerializeField] private TrackPartPool _trackPartPool;
    [SerializeField] private ObstacleDataSequencer _obstacleDataSequencer;
    private void Awake()
    {
        _trackGenerationCondition.OnGenerateTrack += GenerateTrack;
    }


    private void GenerateTrack(TrackSpawnParams trackSpawnParams)
    {
        var track = _trackPartPool.Get();
        track.Initialize(_obstacleDataSequencer.Next);
        track.Spawn(trackSpawnParams);
    }
}