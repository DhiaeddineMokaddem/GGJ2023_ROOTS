using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CamerController : MonoBehaviour
{
    public float ZoomSpeed;
    public float speed;
    void Update()
    {
        MoveCamera();
        //get left mouse button and rotate around centre
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10f);
            //transform.RotateAround(Vector3.zero, Vector3.right, Input.GetAxis("Mouse Y") * 10f);
        }

        //get mouse roller and zoom out       
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize <= 13)
        {
            //transform.Translate(Vector3.forward * 10f);
            Camera.main.orthographicSize -= ZoomSpeed;
        }
        //get mouse roller and zoom in
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize >= 1)
        {
            Camera.main.orthographicSize += ZoomSpeed;
        }
        //fix the max
        if (Camera.main.orthographicSize > 13)
        {
            Camera.main.orthographicSize = 13f;
        }
        if (Camera.main.orthographicSize < 1)
        {
            Camera.main.orthographicSize = 1f;
        }
    }

    private void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)) * 2;
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1));
        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal) * speed * Time.deltaTime;
        transform.position += moveDirection;
    }
}
