using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Tile currentHit;
    public float waterResource;
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 10000))
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
}
