using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Tile currentHit;
    public TextMeshProUGUI resourceText;
    private float waterResource;
    public float water
    {
        get { return waterResource; }
        set
        {
            waterResource = value;
            resourceText.text = "Water Resource : " + value.ToString("0") + "L";
        }
    }
    public ChoosingCanvas chooseCanvas;
    public bool isChoosing;
    private void Awake()
    {
        if (instance == null)//singleton class
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
        if (!isChoosing)//raycast on tile to move it up
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
        if(currentHit != null)//if already tile moved up
        {
            if (Input.GetMouseButton(0) && currentHit.canBeBuiltOn)//if clicked on tile and tile is empty show canvas to build new roots
            {
                chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
                isChoosing = true;
            }
            else//if clicked on tile and tile is not empty show canvas to upgrade roots
            //if filled show upgrade + cancle canvas
            {
                if (Input.GetMouseButton(0) && !currentHit.canBeBuiltOn)
                {
                    chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
                    isChoosing = true;
                }
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

    //public void UpgradeTurret()
    //{
    //    currentHit.upgradeUnit();
    //    removeFocus();
    //}
    
}
