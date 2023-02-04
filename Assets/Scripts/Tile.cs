using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Unit unit;
    public bool canGoUp;
    public bool filled { get { return unit == null; } }
    private void Update()
    {
        if(canGoUp)
        {
            if (this == GameManager.instance.currentHit)
            {
                goUp();
            }
            else
            {
                goDown();
            }
        }
    }
    public IEnumerator goUp()
    {
        while(transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.5f*Time.deltaTime, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
    public void goDown()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
