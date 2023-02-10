using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCanvas : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradeText;
    public Button upgradeButton;
    protected void Update()
    {
        transform.localScale = Vector3.one * Camera.main.orthographicSize * 0.002f;
        transform.forward = Camera.main.transform.forward;
        if (GameManager.instance.isChoosing)
        {
            if (GameManager.instance.currentHit.filled)
            {
                levelText.text = "level " + GameManager.instance.currentHit.unit.level;
                upgradeText.text = "Upgrade ( "+ (GameManager.instance.currentHit.unit.level * GameManager.instance.currentHit.unit.upgradeCostPerLevel) + "L )";
            }
        }
        if (GameManager.instance.currentHit)
        {
            if (GameManager.instance.currentHit.filled)
            {
                if (GameManager.instance.currentHit.unit.level * GameManager.instance.currentHit.unit.upgradeCostPerLevel < GameManager.instance.water)
                {
                    upgradeButton.interactable= true;
                }
                else
                {
                    upgradeButton.interactable= false;
                }
            }
        }
    }
}
