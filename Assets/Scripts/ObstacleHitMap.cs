using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleHitMap : MonoBehaviour
{
    public HitMap hitMap;
    public List<int> GetHitIndices(float positionX, TrackPositionTracker trackPositionTracker)
    {
        trackPositionTracker.GetPosition(positionX, out int ind1, out int ind2);
        ind1 = 4 - ind1;
        ind2 = 4 - ind2;
        var map1 = hitMap.hitIndices[ind1].hitIndices;
        var map2 = hitMap.hitIndices[ind2].hitIndices;
        List<int> hitIndices = new List<int>();
        hitIndices.AddRange(map1);
        hitIndices.AddRange(map2);
        hitIndices = hitIndices.Distinct().ToList();
        hitIndices.Sort();
        return hitIndices;
    }

    [System.Serializable]
    public class HitMap
    {
        public List<HitIndices> hitIndices = new List<HitIndices>();

        [System.Serializable]
        public class HitIndices
        {
            public List<int> hitIndices;
        }
    }
}