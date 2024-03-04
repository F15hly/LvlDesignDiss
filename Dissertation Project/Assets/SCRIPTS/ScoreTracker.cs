using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int p1Score, p2Score;
    public TextMeshProUGUI p1TXT, p2TXT;

    public GameObject p1, p2, heatCam;

    private void LateUpdate()
    {
        //p1 = GameObject.FindGameObjectWithTag("Player");
        p2 = GameObject.FindGameObjectWithTag("Player1");
        p1TXT.text = p1Score + "";
        p2TXT.text = p2Score + "";
        if(p1.GetComponent<Player_Managment>().defeated)
        {
            p1.GetComponent<Player_Managment>().defeated = false;
            p1Score += 1;
        }
        if (p2.GetComponent<Player_Managment1>().defeated)
        {
            p2.GetComponent<Player_Managment1>().defeated = false;
            p2Score += 1;
        }
        if(p1Score >= 20 || p2Score >= 20)
        {
            Destroy(p1);
            Destroy(p2);
            heatCam.SetActive(true);
        }
    }
}
