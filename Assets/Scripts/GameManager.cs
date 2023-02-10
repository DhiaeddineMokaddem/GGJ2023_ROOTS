using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timePassed;
    public Tile currentHit;
    public TextMeshProUGUI resourceText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winText;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    private float waterResource=50f;
    public float waterAmountToWin;
    public float water
    {
        get { return waterResource; }
        set
        {
            waterResource = value;
            resourceText.text = "Water Resource : " + value.ToString("0.0") + "L";
            if(water > waterAmountToWin)
            {
                Win();
            }
        }
    }
    public ChoosingCanvas chooseCanvas;
    public UpgradeCanvas upgradeCanvas;
    public bool isChoosing;

    public int attackTurrCost;
    public int rootTurrCost;
    public int defenceTurrCost;
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
    private void Start()
    {
        Time.timeScale= 1;
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        float[] x = GetTimeComponents(timePassed);
        timeText.text = x[0] + "h " + x[1] + "m " + x[2] + "s";
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
        removeFocus();
        if(theUnit.placementCost < water)
        {
            currentHit.spawnUnit(theUnit);
            water -= theUnit.placementCost;
        }
    }
    public void removeFocus()
    {
        chooseCanvas.transform.position = new Vector3(currentHit.transform.position.x, 1000, currentHit.transform.position.z);
        upgradeCanvas.transform.position = new Vector3(currentHit.transform.position.x, 1000, currentHit.transform.position.z);
        isChoosing = false;
    }
    public void UpgradeTurret()
    {
        removeFocus();
        if(currentHit.unit.level* currentHit.unit.upgradeCostPerLevel < water)
        {
            water -= currentHit.unit.level * currentHit.unit.upgradeCostPerLevel;
            currentHit.unit.Upgrade();
        }
    }
    public void KillPlant()
    {
        if (currentHit.filled)
        {
            removeFocus();
            currentHit.unit.die();
        }
    }
    public void Win()
    {
        winText.text = "in " + timeText.text + ", play again and try to beat your score";
        winCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Lose()
    {
        loseCanvas.gameObject.SetActive(true);
        Time.timeScale= 0;
    }
    public void addWater(float Amount)
    {
        water += Amount;
    }
    public float[] GetTimeComponents(float timeInSeconds)
    {
        float[] timeComponents = new float[3];

        timeComponents[0] = Mathf.Floor(timeInSeconds / 3600);
        timeComponents[1] = Mathf.Floor((timeInSeconds % 3600) / 60);
        timeComponents[2] = Mathf.Floor(timeInSeconds % 60);

        return timeComponents;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
