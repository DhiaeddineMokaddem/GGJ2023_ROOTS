using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum tileTypes
{
    normal,
    water,
    waterBorder
}
public class Tile : MonoBehaviour
{
    [SerializeField] bool isDown=true;
    [SerializeField] GameObject rootLinks;
    public Unit unit; //the unit that occupies this tile
    public bool canGoUp; //if the tile can go up when hovered over
    public bool filled { get { return unit != null; } } //checks if the tile has a unit on it
    private void Update()
    {
        if(canGoUp)
        {
            if (this == GameManager.instance.currentHit) //checks if itself is the tile that is being hovered over
            {
                if (!isDown) return;
                StartCoroutine(goUp());
                //goes up if so
                //isDown = false;
                //Debug.Log("is down false");
            }
            else if (!isDown) //checks if itself is not the tile that is being hovered over            
            {
                StartCoroutine(goDown()); //stays down or goes back down (unoptemized)
                //isDown = true;
                //Debug.Log("is down true");
                //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }
    [SerializeField] float Speed = 0.5f;
    [SerializeField] float Distance = 0.5f;
    public void spawnUnit(Unit unitToSpawn)
    {
        if (!filled)
        {
            unit = unitToSpawn;
            Instantiate(unit, transform);
            rootLinks.SetActive(true);
        }
    }
    public IEnumerator goUp() //moves tiles up by distance
    {    
        StopCoroutine("goUp");
        while (transform.position.y < Distance)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + Speed * Time.deltaTime, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, Distance, transform.position.z);
        isDown = false;
    }
    public IEnumerator goDown() //moves tiles to initial state
    {
        StopCoroutine("goDown");
        while (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        isDown = true;
    }

}
