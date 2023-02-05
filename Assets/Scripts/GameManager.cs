using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Tile currentHit;
    public float waterResource;
    public ChoosingCanvas chooseCanvas;
    public bool isChoosing;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if (!isChoosing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int mask = 1 << LayerMask.NameToLayer("Tile");
            if (Physics.Raycast(ray, out RaycastHit hit, 10000, mask) && !Input.GetMouseButtonDown(1))
            {
                if (hit.transform.tag == "Tile")
                {
                    currentHit = hit.transform.GetComponent<Tile>();
                }
            }
            else
            {
                currentHit = null;
            }
        }
        if(currentHit != null)
        {
            if (Input.GetMouseButton(0))
            {
                chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
                isChoosing = true;
            }
        }
    }
    public void SpawnTurret(Unit theUnit)
    {
        currentHit.spawnUnit(theUnit);
        removeFocus();
    }
    public void removeFocus()
    {
        chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 1000, currentHit.transform.position.z);
        isChoosing = false;
    }
}
