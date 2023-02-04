using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Unit unit;
    public bool filled { get { return unit == null; } }
    private void Update()
    {
        if(this == GameManager.instance.currentHit)
        {
            goUp();
        }
        else
        {
            goDown();
        }
    }
    public void goUp()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
    public void goDown()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
