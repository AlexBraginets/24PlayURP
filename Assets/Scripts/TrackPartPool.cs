using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackPartPool : MonoBehaviour
{
   [SerializeField] private TrackPart _trackPartPrefab;
   [SerializeField] private List<TrackPart> _trackParts = new List<TrackPart>();
   public static TrackPartPool Instance { get; private set; }

   private void Awake()
   {
      Instance = this;
   }

   public TrackPart Get()
   {
      TrackPart trackPart = _trackParts.FirstOrDefault(x => x.Inactive);
      if (trackPart == null)
      {
         trackPart = Instantiate(_trackPartPrefab);
         _trackParts.Add(trackPart);
      }
      return trackPart;
   }
   
}
