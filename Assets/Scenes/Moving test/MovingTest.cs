using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTest : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionCopy = transform.position;
        transform.position  = transform.position + Vector3.forward * (Time.deltaTime * speed);
        float dz = (transform.position - positionCopy).z;
        Debug.Log($"frame: {Time.frameCount} dz: {dz}");
    }
}
