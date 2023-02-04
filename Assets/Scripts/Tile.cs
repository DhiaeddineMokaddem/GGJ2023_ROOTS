using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Unit unit; //the unit that occupies this tile
    public bool canGoUp; //if the tile can go up when hovered over
    public bool filled { get { return unit == null; } } //checks if the tile has a unit on it
    private void Update()
    {
        Debug.Log(GameManager.instance.currentHit);
        if(canGoUp)
        {
            if (this == GameManager.instance.currentHit) //checks if itself is the tile that is being hovered over
            {
                StartCoroutine(goUp()); //goes up if so
            }
            else
            {
                StartCoroutine(goDown()); //stays down or goes back down (unoptemized)
            }
        }
    }
    public IEnumerator goUp() //inprogress
    {
        StopCoroutine("goUp");
        while (transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.5f*Time.deltaTime, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
    public IEnumerator goDown() //inprogress
    {
        StopCoroutine("goDown");
        while (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
