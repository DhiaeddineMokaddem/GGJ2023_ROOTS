using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeCanvas : ChoosingCanvas
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradeText;
    protected new void Update()
    {
        base.Update();
        if(GameManager.instance.isChoosing)
        {
            if (GameManager.instance.currentHit.filled)
            {
                levelText.text = "level " + GameManager.instance.currentHit.unit.level;
                upgradeText.text = "Upgrade ( "+ (GameManager.instance.currentHit.unit.level * GameManager.instance.currentHit.unit.upgradeCostPerLevel) + "L )";
            }
        }
    }
}
