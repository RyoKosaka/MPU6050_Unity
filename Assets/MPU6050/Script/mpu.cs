using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mpu: MonoBehaviour
{

    public SerialHandler serialHandler;
    public GameObject NorthStar;

    // Use this for initialization
    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnDataReceived(string message)
    {
        try
        {
            string[] angles = message.Split(',');
            //Vector3 angle = new Vector3(float.Parse(angles[0]), float.Parse(angles[2]), float.Parse(angles[1]));
            //cube.transform.rotation = Quaternion.Euler(angle);
            NorthStar.transform.rotation = new Quaternion(float.Parse(angles[0]), float.Parse(angles[1]), float.Parse(angles[3]), float.Parse(angles[2]));
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}