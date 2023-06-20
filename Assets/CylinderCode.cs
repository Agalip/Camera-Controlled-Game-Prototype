using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderCode : MonoBehaviour
{
    public Transform origin;
    public Transform destination;
    public float radius = 0.1f;
    MeshRenderer cylinder;

    // Start is called before the first frame update
    void Start()
    {
        // Create the cylinder game object
        cylinder = GetComponent<MeshRenderer>();

        // Set the scale of the cylinder based on the distance between the two points
        float distance = Vector3.Distance(origin.position, destination.position);
        cylinder.transform.localScale = new Vector3(radius, distance / 2, radius);
        print(radius);
        // Set the position of the cylinder to the midpoint between the two points
        cylinder.transform.position = (origin.position + destination.position) / 2;

        // Set the rotation of the cylinder to point from origin to destination
        cylinder.transform.LookAt(destination.position);

        // Rotate the cylinder 90 degrees around the x-axis to make it horizontal
        cylinder.transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90f, cylinder.transform.eulerAngles.y, cylinder.transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the scale and position of the cylinder in case the origin or destination has moved
        float distance = Vector3.Distance(origin.position, destination.position);

        cylinder.transform.localScale = new Vector3(radius, distance / 2, radius);
        cylinder.transform.position = (origin.position + destination.position) / 2;
        cylinder.transform.LookAt(destination.position);

        // Rotate the cylinder 90 degrees around the x-axis to make it horizontal
        cylinder.transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90f, cylinder.transform.eulerAngles.y, cylinder.transform.eulerAngles.z);
        print(radius);
    }

}