using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //attach to ball

    public static int scoreLeft = 0;
    public static int scoreRight = 0;

    public static bool inThreePoint = false;
    public static bool hit = false;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    public AudioClip[] score;

    private void OnTriggerEnter(Collider other)
    {
        hit = true;

        if(other.name.Equals("Net Score Hitbox Right") && Player.shotBall)
        {
            if(inThreePoint)
            {
                scoreLeft += 2;
                int rand = Random.Range(0, 4);
                this.GetComponent<AudioSource>().clip = score[rand];
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                scoreLeft += 3;
                int rand = Random.Range(0, 4);
                this.GetComponent<AudioSource>().clip = score[rand];
                this.GetComponent<AudioSource>().Play();
            }
            Player.shotBall = false;
        }
        else if(other.name.Equals("Net Score Hitbox Left") && Player2.shotBall)
        {
            if (inThreePoint)
            {
                scoreRight += 2;
                int rand = Random.Range(0, 4);
                this.GetComponent<AudioSource>().clip = score[rand];
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                scoreRight += 3;
                int rand = Random.Range(0, 4);
                this.GetComponent<AudioSource>().clip = score[rand];
                this.GetComponent<AudioSource>().Play();
            }
            Player2.shotBall = false;
        }
    }

    // Update is called once per frame
    void Update () {
        hit = false;
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
	}
}
