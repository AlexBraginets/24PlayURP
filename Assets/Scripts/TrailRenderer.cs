using System.Collections.Generic;
using UnityEngine;

public class TrailRenderer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LineRenderer _lineRenderer;
    private List<Vector3> _points = new List<Vector3>();
    private void LateUpdate()
    {
        _points.Add(player.position + Vector3.up * .01f);
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
    }
}
