using System;
using Data;
using UnityEngine;

public class StackNewCubeTrigger : MonoBehaviour
{
    public event Action<GameObject> OnPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Tags.PICKUP_CUBE)) return;
        OnPickup?.Invoke(other.gameObject);
    }
}