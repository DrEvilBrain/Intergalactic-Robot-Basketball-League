using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    public GameObject ball;

    public Renderer mesh;

    public static bool ballPickUp;
    public static bool shotBall;
    public static bool visible;
    private bool hitPlayer;

    public AudioClip[] swish;

	// Use this for initialization
	void Start () {
        ballPickUp = false;
        shotBall = false;
        hitPlayer = false;
        visible = true;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.Equals(ball.GetComponent<Collider>()))
        {
            ballPickUp = true;
        }
        if(collision.collider.name.Equals("Player 2"))
        {
            hitPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.name.Equals("Player 2"))
        {
            hitPlayer = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Score.hit && other.name.Equals("InThreePointRight"))
        {
            Score.inThreePoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("InThreePointRight"))
        {
            Score.inThreePoint = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if(mesh.isVisible)
        {
            visible = true;
        }
        else
        {
            visible = false;
        }

        if (ballPickUp == true)
        {
            ball.transform.SetParent(player.transform);
            ball.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
            CameraMovement.player = player;
            Trajectory.player = player;

            if (Input.GetButtonDown("Shoot Block"))
            {
                ballPickUp = false;
                shotBall = true;
                ball.transform.parent = null;
                Trajectory.startThrow = true;

                int rand = Random.Range(0, 12);
                this.GetComponent<AudioSource>().clip = swish[rand];
                this.GetComponent<AudioSource>().Play();
            }
        }  
        if(hitPlayer)
        {
            //if (Input.GetButtonDown("Pass Steal"))
            //{
            //    ballPickUp = true;
            //}
        }
    }
}