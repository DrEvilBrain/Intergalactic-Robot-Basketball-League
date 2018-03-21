using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public static float timeLeft;
    public Text timer;

    public Text P1;
    public Text P2;
    public Text Draw;
    public Text Menu;

    public static bool gameEnd;

    // Use this for initialization
    void Start () {
        timeLeft = 300; //5 min
        Draw.enabled = false;
        P1.enabled = false;
        P2.enabled = false;
        Menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString("F0");

        if(timeLeft <= 0)
        {
            gameEnd = true;

            if (Score.scoreRight == Score.scoreLeft)
            {
                Draw.enabled = true;
            }
            else if(Score.scoreLeft > Score.scoreRight)
            {
                P1.enabled = true;
            }
            else if(Score.scoreRight > Score.scoreLeft)
            {
                P2.enabled = true;
            }
            Menu.enabled = true;
        }
        else
        {
            gameEnd = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
            Time.timeScale = 1;
        }
    }

    private void LateUpdate()
    {
        if (gameEnd)
        {
            Time.timeScale = 0;
        }
    }
}
