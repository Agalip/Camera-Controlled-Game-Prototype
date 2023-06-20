using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder4Code : MonoBehaviour
{
    public Transform[] referencePoints;
    MeshRenderer cylinder;
    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        // Create the cylinder game object
        cylinder = GetComponent<MeshRenderer>();

        // Set the origin as the mean of the first two reference points
        Vector3 originPos = (referencePoints[0].position + referencePoints[1].position) / 2;

        // Set the destination as the mean of the last two reference points
        Vector3 destPos = (referencePoints[2].position + referencePoints[3].position) / 2;

        // Calculate the distance between the first two reference points
        float distance2 = Vector3.Distance(referencePoints[0].position, referencePoints[1].position);

        // Calculate the radius of the cylinder based on the distance between the first two reference points
        radius = distance2 / 2;

        // Set the scale of the cylinder based on the distance between the two points
        float distance = Vector3.Distance(originPos, destPos);
        cylinder.transform.localScale = new Vector3(radius, distance / 2, radius);

        // Set the position of the cylinder to the midpoint between the two points
        cylinder.transform.position = (originPos + destPos) / 2;

        // Calculate the direction from origin to destination
        Vector3 direction = destPos - originPos;

        // Set the rotation of the cylinder to point from origin to destination
        cylinder.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Rotate the cylinder 90 degrees around the x-axis to make it vertical
        cylinder.transform.Rotate(90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the origin as the mean of the first two reference points
        Vector3 originPos = (referencePoints[0].position + referencePoints[1].position) / 2;

        // Set the destination as the mean of the last two reference points
        Vector3 destPos = (referencePoints[2].position + referencePoints[3].position) / 2;

        // Calculate the distance between the first two reference points
        float distance2 = Vector3.Distance(referencePoints[0].position, referencePoints[1].position);

        // Calculate the radius of the cylinder based on the distance between the first two reference points
        radius = distance2 / 2;

        // Update the scale and position of the cylinder in case the reference points have moved
        float distance = Vector3.Distance(originPos, destPos);
        cylinder.transform.localScale = new Vector3(radius, distance / 2, radius);
        cylinder.transform.position = (originPos + destPos) / 2;

        // Calculate the direction from origin to destination
        Vector3 direction = destPos - originPos;

        // Set the rotation of the cylinder to point from origin to destination
        cylinder.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Rotate the cylinder 90 degrees around the x-axis to make it vertical
        cylinder.transform.Rotate(90f, 0f, 0f);
    }
}