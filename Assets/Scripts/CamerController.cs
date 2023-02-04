using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{

    public float ZoomSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get left mouse button and rotate around centre
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * 10f);
            //transform.RotateAround(Vector3.zero, Vector3.right, Input.GetAxis("Mouse Y") * 10f);
        }
        //get mouse roller and zoom in and out
        if (Camera.main.orthographicSize >= 1)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                //transform.Translate(Vector3.forward * 10f);
                Camera.main.orthographicSize -= ZoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                //transform.Translate(Vector3.back * 10f);
                Camera.main.orthographicSize += ZoomSpeed;
            }
        }
        else
        {
            Camera.main.orthographicSize = 1;
        }




    }
}
