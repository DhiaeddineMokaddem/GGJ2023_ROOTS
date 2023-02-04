using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingCanvas : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = Vector3.one * Camera.main.orthographicSize * 0.002f;
        transform.forward = Camera.main.transform.forward;
    }
}
