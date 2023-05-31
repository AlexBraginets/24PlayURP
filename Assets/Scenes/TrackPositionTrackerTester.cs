using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPositionTrackerTester : MonoBehaviour
{
    [SerializeField] private GameObject[] positions;
    [SerializeField] private TrackPositionTracker _trackPositionTracker;

    private void Update()
    {
        _trackPositionTracker.GetPosition(transform.position.x, out int pos1, out int pos2);
        Apply(pos1, pos2);
    }

    private void Apply(int ind1, int ind2)
    {
        foreach (var position in positions)
        {
            position.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }

        positions[ind1].GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
        ;
        positions[ind2].GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
        ;
    }
}