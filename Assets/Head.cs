using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform pointA; // First point
    public Transform pointB; // Second point
    public float scaleFactor = 1.0f; // Adjust this value to control the scaling factor

    private void Update()
    {
        // Calculate the distance between pointA and pointB
        float distance = Vector3.Distance(pointA.position, pointB.position);

        // Scale the sphere based on the distance between the points
        transform.localScale = Vector3.one * distance * scaleFactor;
    }
}
