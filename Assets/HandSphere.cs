using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSphere : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float radiusMultiplier = 1.0f;

    MeshRenderer sphere;

    // Start is called before the first frame update
    void Start()
    {
        // Create the sphere game object
        sphere = GetComponent<MeshRenderer>();

        // Calculate the center point of the three reference points
        Vector3 centerPoint = (pointA.position + pointB.position + pointC.position) / 3;

        // Set the position of the sphere to the center point
        sphere.transform.position = centerPoint;

        // Calculate the distance between the center point and each reference point
        float distanceA = Vector3.Distance(centerPoint, pointA.position);
        float distanceB = Vector3.Distance(centerPoint, pointB.position);
        float distanceC = Vector3.Distance(centerPoint, pointC.position);

        // Calculate the maximum distance among the three distances
        float maxDistance = Mathf.Max(distanceA, distanceB, distanceC);

        // Calculate the radius based on the maximum distance and the radius multiplier
        float radius = maxDistance * radiusMultiplier;

        // Set the scale of the sphere based on the radius
        sphere.transform.localScale = new Vector3(radius, radius, radius);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the center point of the three reference points
        Vector3 centerPoint = (pointA.position + pointB.position + pointC.position) / 3;

        // Set the position of the sphere to the center point
        sphere.transform.position = centerPoint;

        // Calculate the distance between the center point and each reference point
        float distanceA = Vector3.Distance(centerPoint, pointA.position);
        float distanceB = Vector3.Distance(centerPoint, pointB.position);
        float distanceC = Vector3.Distance(centerPoint, pointC.position);

        // Calculate the maximum distance among the three distances
        float maxDistance = Mathf.Max(distanceA, distanceB, distanceC);

        // Calculate the radius based on the maximum distance and the radius multiplier
        float radius = maxDistance * radiusMultiplier;

        // Set the scale of the sphere based on the radius
        sphere.transform.localScale = new Vector3(radius, radius, radius);
    }
}
