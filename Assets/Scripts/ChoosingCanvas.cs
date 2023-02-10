using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingCanvas : MonoBehaviour
{
    public Button attack;
    public Button defence;
    public Button root;
    protected void Update()
    {
        transform.localScale = Vector3.one * Camera.main.orthographicSize * 0.002f;
        transform.forward = Camera.main.transform.forward;
        if (GameManager.instance.water < GameManager.instance.attackTurrCost)
        {
            attack.interactable = false;
        }
        else
        {
            attack.interactable = true;
        }
        if (GameManager.instance.water < GameManager.instance.defenceTurrCost)
        {
            defence.interactable = false;
        }
        else
        {
            defence.interactable = true;
        }
        if (GameManager.instance.water < GameManager.instance.rootTurrCost)
        {
            root.interactable = false;
        }
        else
        {
            root.interactable = true;
        }
    }
}
