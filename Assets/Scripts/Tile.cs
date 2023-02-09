using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum tileTypes
{
    normal,
    waterBorder
}
public class Tile : MonoBehaviour
{
    [SerializeField] bool isDown=true;
    [SerializeField] GameObject rootLinks;
    public Unit unit; //the unit that occupies this tile
    [SerializeField] float Speed;
    [SerializeField] float Distance;
    public bool canGoUp; //if the tile can go up when hovered over
    public bool canBeBuiltOn;//if the tile has other roots near it 
    public bool canBeMadeBuildable;
    [SerializeField] tileTypes myType;
    [SerializeField] MeshRenderer myMesh;
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
        if(myType == tileTypes.waterBorder && unit is RessourceUnit)
        {
            RessourceUnit x = (RessourceUnit)unit;
            x.Generate(x.resourceGenerateRate * Time.deltaTime);
            Debug.Log(x.resourceGenerateRate);
        }
    }
    private void Start()
    {
        if (canBeBuiltOn)
        {
            myMesh.material.color = Color.white;
        }
        else
        {
            myMesh.material.color = Color.grey;
        }
    }
    public void spawnUnit(Unit unitToSpawn)
    {
        if (!filled && canBeBuiltOn)
        {
            unit = Instantiate(unitToSpawn, transform);
            unit.myTile = this;
            rootLinks.SetActive(true);
            Ray ray = new Ray(transform.position, Vector3.right);
            int mask = 1 << LayerMask.NameToLayer("Tile");
            if (Physics.Raycast(ray, out RaycastHit hit, 1, mask))
            {
                hit.transform.GetComponent<Tile>().makeMeSpawnabble();
            }
            ray = new Ray(transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out RaycastHit hit2, 1, mask))
            {
                hit2.transform.GetComponent<Tile>().makeMeSpawnabble();
            }
            ray = new Ray(transform.position, Vector3.left);
            if (Physics.Raycast(ray, out RaycastHit hit3, 1, mask))
            {
                hit3.transform.GetComponent<Tile>().makeMeSpawnabble();
            }
            ray = new Ray(transform.position, Vector3.back);
            if (Physics.Raycast(ray, out RaycastHit hit4, 1, mask))
            {
                hit4.transform.GetComponent<Tile>().makeMeSpawnabble();
            }
        }
    }
    public void UnspawnUnit()
    {
        unit = null;
        rootLinks.SetActive(false);
        MakeSureNeighborsAreStillAvalable();
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
    public void makeMeSpawnabble()
    {
        if(canBeMadeBuildable)
        {
            canBeBuiltOn = true;
            canGoUp = true;
            myMesh.material.color = Color.white;
        }
    }
    public void makeMeUnspawnabble()
    {
        if (canBeMadeBuildable)
        {
            canBeBuiltOn = false;
            canGoUp = false;
            myMesh.material.color = Color.grey;
        }
    }
    public void MakeSureNeighborsAreStillAvalable()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        int mask = 1 << LayerMask.NameToLayer("Tile");
        if (Physics.Raycast(ray, out RaycastHit hit, 1, mask))
        {
            hit.transform.GetComponent<Tile>().MakeSureImStillAvalable();
        }
        ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out RaycastHit hit2, 1, mask))
        {
            hit2.transform.GetComponent<Tile>().MakeSureImStillAvalable();
        }
        ray = new Ray(transform.position, Vector3.left);
        if (Physics.Raycast(ray, out RaycastHit hit3, 1, mask))
        {
            hit3.transform.GetComponent<Tile>().MakeSureImStillAvalable();
        }
        ray = new Ray(transform.position, Vector3.back);
        if (Physics.Raycast(ray, out RaycastHit hit4, 1, mask))
        {
            hit4.transform.GetComponent<Tile>().MakeSureImStillAvalable();
        }
    }
    public void MakeSureImStillAvalable()
    {
        bool isSure = false;
        if (filled)
        {
            isSure = true;
        }
        else
        {
            Ray ray = new Ray(transform.position, Vector3.right);
            int mask = 1 << LayerMask.NameToLayer("Tile");
            if (Physics.Raycast(ray, out RaycastHit hit, 1, mask))
            {
                if (hit.transform.GetComponent<Tile>().filled)
                {
                    isSure = true;
                }
            }
            else
            {
                ray = new Ray(transform.position, Vector3.forward);
                if (Physics.Raycast(ray, out RaycastHit hit2, 1, mask))
                {
                    if (hit2.transform.GetComponent<Tile>().filled)
                    {
                        isSure = true;
                    }
                }
                else
                {
                    ray = new Ray(transform.position, Vector3.left);
                    if (Physics.Raycast(ray, out RaycastHit hit3, 1, mask))
                    {
                        if (hit3.transform.GetComponent<Tile>().filled)
                        {
                            isSure = true;
                        }
                    }
                    else
                    {
                        ray = new Ray(transform.position, Vector3.back);
                        if (Physics.Raycast(ray, out RaycastHit hit4, 1, mask))
                        {
                            if (hit4.transform.GetComponent<Tile>().filled)
                            {
                                isSure = true;
                            }
                        }
                    }
                }
            }
            if (!isSure)
            {
                makeMeUnspawnabble();
            }
        }
    }
}
