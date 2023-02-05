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
        MoveCamera();
        //get left mouse button and rotate around centre
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * 10f);
            //transform.RotateAround(Vector3.zero, Vector3.right, Input.GetAxis("Mouse Y") * 10f);
        }

        

        //get mouse roller and zoom out       
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize <= 13)
        {
            //transform.Translate(Vector3.forward * 10f);
            Camera.main.orthographicSize -= ZoomSpeed;
        }
        else if (Camera.main.orthographicSize > 13)
        {
            Camera.main.orthographicSize = 13f;
        }

        //get mouse roller and zoom in
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize >= 1)
        {
            //transform.Translate(Vector3.back * 10f);
            Camera.main.orthographicSize += ZoomSpeed;
        }
        else if (Camera.main.orthographicSize < 1)
        {
            Camera.main.orthographicSize = 1f;
        }
    }

    private void MoveCamera()
    {
        //move camera on x and z axis using arrow keys
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 16f)
        {
            transform.Translate(Vector3.forward.normalized * Time.deltaTime * 10f, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -16f)
        {
            transform.Translate(Vector3.back.normalized * Time.deltaTime * 10f, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -16f)
        {
            transform.Translate(Vector3.left.normalized * Time.deltaTime * 10f, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 16f)
        {
            transform.Translate(Vector3.right.normalized * Time.deltaTime * 10f, Space.World);
        }
    }
}
