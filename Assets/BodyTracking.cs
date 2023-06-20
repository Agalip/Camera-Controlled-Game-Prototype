using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking : MonoBehaviour
{
    // Start is called before the first frame update

    public UDPReceive udpReceive;
    public GameObject[] bodyPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        //print(data);

        string[] points = data.Split(',');
        //print(points[0]);


        for (int i =0; i<33; i++)
        {

            float x = float.Parse(points[i * 3], 
                               System.Globalization.CultureInfo.InvariantCulture);
            float y = 3*float.Parse(points[i * 3 + 1],
                               System.Globalization.CultureInfo.InvariantCulture);
            float z = 3*float.Parse(points[i * 3 + 2],
                               System.Globalization.CultureInfo.InvariantCulture);

            float scaledX = x * (5f) - 2.5f;

            if (i == 0)
            {
                bodyPoints[i].transform.localPosition = new Vector3(scaledX, y, z+1f);

            }
            else
            {
                bodyPoints[i].transform.localPosition = new Vector3(scaledX, y, z);

            }

        }



    }
}
