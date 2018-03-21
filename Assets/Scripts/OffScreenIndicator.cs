using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffScreenIndicator : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public Image p1arrow;
    public Image p2arrow;

    private float p1y;
    private float p2y;

    public Camera cam;

    private Vector3 screenPos;

    private void Start()
    {
        p1arrow.enabled = false;
        p2arrow.enabled = false;
    }

    // Update is called once per frame
    void Update () {
		if(!Player.visible)
        {
            screenPos = cam.WorldToScreenPoint(player1.transform.position);
            p1y = Mathf.Lerp(-285f, 285f, screenPos.z);
            p1arrow.transform.localPosition = new Vector3(p1arrow.transform.localPosition.x, p1y, p1arrow.transform.localPosition.z);
            p1arrow.enabled = true;
        }
        else
        {
            p1arrow.enabled = false;
        }

        if(!Player2.visible)
        {
            screenPos = cam.WorldToScreenPoint(player2.transform.position);
            p2y = Mathf.Lerp(-285f, 285f, screenPos.z);
            p2arrow.transform.localPosition = new Vector3(p2arrow.transform.localPosition.x, p1y, p2arrow.transform.localPosition.z);
            p2arrow.enabled = true;
        }
        else
        {
            p2arrow.enabled = false;
        }
	}
}
