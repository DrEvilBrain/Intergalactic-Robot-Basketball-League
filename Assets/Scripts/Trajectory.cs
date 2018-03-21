using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    public static GameObject player;
    public GameObject netL;
    public GameObject netR;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 currentPos;

    float height = 2;
    float incrementor = 0;

    public static bool startThrow = false;

    private void Start()
    {
        currentPos = new Vector3(0, 0, 0);
        startPos = new Vector3(0, 0, 0);
        endPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.name.Equals("Player"))
        {
            endPos = new Vector3(netR.transform.position.x, netR.transform.position.y, netR.transform.position.z);
        }
        else if (player != null && player.name.Equals("Player 2"))
        {
            endPos = new Vector3(netL.transform.position.x, netL.transform.position.y, netL.transform.position.z);
        }

        currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); //update values
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (startThrow && Time.timeScale != 0)
        {
            incrementor += 0.025f;
            Vector3 currentPos = Vector3.Lerp(startPos, endPos, incrementor);
            currentPos.y += height * Mathf.Sin(Mathf.Clamp01(incrementor) * Mathf.PI);
            transform.position = currentPos;
        }

        if (transform.position == endPos)
        {
            startThrow = false;
            incrementor = 0;
            Vector3 tempPos = startPos;
            startPos = transform.position;
            endPos = tempPos;
        }
    }
}