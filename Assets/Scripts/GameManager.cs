using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tile currentHit;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 10000))
        {
            if (hit.transform.tag == "Tile")
            {
                if (hit.Equals(currentHit))
                {
                    currentHit.transform.GetComponent<Tile>().goDown();
                    hit.transform.GetComponent<Tile>().goUp();
                }
                currentHit = hit.transform.GetComponent<Tile>();
            }
        }
    }
}
