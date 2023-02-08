using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Tile currentHit;
    public TextMeshProUGUI resourceText;
    private float waterResource=50f;
    public float water
    {
        get { return waterResource; }
        set
        {
            waterResource = value;
            resourceText.text = "Water Resource : " + value.ToString("0.0") + "L";
        }
    }
    public ChoosingCanvas chooseCanvas;
    public ChoosingCanvas upgradeCanvas;
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
                if (!currentHit.filled)
                {
                    chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
                    isChoosing = true;
                }
                else
                {
                    upgradeCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
                    isChoosing = true;
                }
            }
            //else (Input.GetMouseButton(0)
            ////if clicked on tile and tile is not empty show canvas to upgrade roots
            ////if filled show upgrade + cancle canvas
            //{
            //    if (Input.GetMouseButton(0) && !currentHit.canBeBuiltOn)
            //    {
            //        chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 2, currentHit.transform.position.z);
            //        isChoosing = true;
            //    }
            //}
        }
    }
    public void SpawnTurret(Unit theUnit)
    {
        if(theUnit.placementCost < water)
        {
            currentHit.spawnUnit(theUnit);
            water -= theUnit.placementCost;
        }
        removeFocus();
    }
    public void removeFocus()
    {
        chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 1000, currentHit.transform.position.z);
        upgradeCanvas.transform.position = new Vector3(currentHit.transform.position.x, 1000, currentHit.transform.position.z);
        isChoosing = false;
    }

    public void UpgradeTurret()
    {
        Debug.Log("made it here");
        if (currentHit.unit is RessourceUnit)
        {
            RessourceUnit x = (RessourceUnit)currentHit.unit;
            if(x.Recouceplant[0] < GameManager.instance.water)
            {
                x.Recouceplant[0] += 2f;
                x.Recouceplant[1] += 2f;
                x.Recouceplant[3] += 0.2f;
                Debug.Log(x.Recouceplant[0] + "/" + x.Recouceplant[1] + "/" + x.Recouceplant[2]);
                GameManager.instance.water -= x.Recouceplant[0];
            }
        }
        if (currentHit.unit is AttackUnit)
        {
            AttackUnit x = (AttackUnit)currentHit.unit;
            if (x.Attackplant[0] < GameManager.instance.water)
            {
                x.Attackplant[0] += 2f;
                x.Attackplant[1] += 2f;
                x.Attackplant[3] += 01f;
                Debug.Log(x.Attackplant[0] + "/" + x.Attackplant[1] + "/" + x.Attackplant[2]);
                GameManager.instance.water -= x.Attackplant[0];
            }
        }
        
        if (currentHit.unit is DefenderUnit)
        {
            DefenderUnit x = (DefenderUnit)currentHit.unit;
            if (x.deffenseplant[0] < GameManager.instance.water)
            {
                x.deffenseplant[0] += 2f;
                x.deffenseplant[1] += 3f;
                Debug.Log(x.deffenseplant[0] + "/" + x.deffenseplant[1]);
                GameManager.instance.water -= x.deffenseplant[0];
            }
        }
        
        removeFocus();
    }

}
