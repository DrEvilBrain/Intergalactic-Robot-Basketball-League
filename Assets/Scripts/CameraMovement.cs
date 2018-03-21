using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public static GameObject player = null;
    public GameObject ball;
    public GameObject cam;

    private float xpos = 0;
    private float ypos = 0;

    private void LateUpdate()
    {
        if (!Player.ballPickUp && !Player2.ballPickUp)
        {
            xpos = ball.transform.position.x;
            ypos = 4;
        }
        else if(player != null)
        {
            xpos = player.transform.position.x;
            ypos = player.transform.position.y + 3.3073602f;
        }

        if (xpos > 11.5f)
        {
            xpos = 11.5f;
        }
        else if (xpos < -11.5f)
        {
            xpos = -11.5f;
        }

        cam.transform.position = new Vector3(xpos, 4, 5);
    }
}
