using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float offset = 1f;

    private float screenTop;
    private float screenBottom;
    private float screenLeft;
    private float screenRight;

    private void Start()
    {
        // Get the bounds of the screen in world space
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        screenTop = topRight.y + offset;
        screenBottom = bottomLeft.y - offset;
        screenLeft = bottomLeft.x - offset;
        screenRight = topRight.x + offset;
    }

    private void Update()
    {
        // Generate a random x and y coordinate within the bounds of the spawning area
        float x = Random.Range(screenLeft, screenRight);
        float y = Random.Range(screenBottom, screenTop);

        // Create the object and set its position
        GameObject obj = Instantiate(prefab, new Vector3(x, 1f, y), Quaternion.identity);

        // Activate the object
        obj.SetActive(true);
    }
}
