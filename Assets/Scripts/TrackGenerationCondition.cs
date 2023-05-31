using System;
using UnityEngine;

public class TrackGenerationCondition : MonoBehaviour
{
    public event Action<TrackSpawnParams> OnGenerateTrack;

    protected void GenerateTrack(TrackSpawnParams trackSpawnParams)
    {
        OnGenerateTrack?.Invoke(trackSpawnParams);
    }
    
}
