using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int p1Score, p2Score;
    public TextMeshProUGUI p1TXT, p2TXT;

    public GameObject p1, p2, heatCam, heatSigP1, heatSigP2;

    private void LateUpdate()
    {
        Cursor.visible = false;
        p1 = GameObject.FindGameObjectWithTag("Player");
        p2 = GameObject.FindGameObjectWithTag("Player2");
        //p1TXT.text = p1Score + "";
        //p2TXT.text = p2Score + "";
        if(p1.GetComponent<Player_Managment>().defeated)
        {
            p1.GetComponent<Player_Managment>().defeated = false;
            p2Score += 1;
            p2.GetComponent<Player_Managment1>().HP = 100;
            Instantiate(heatSigP2, new Vector3(p2.transform.position.x,21, p2.transform.position.z), Quaternion.Euler(0, 0, 0));
        }
        if (p2.GetComponent<Player_Managment1>().defeated)
        {
            p2.GetComponent<Player_Managment1>().defeated = false;
            p1Score += 1;
            p1.GetComponent<Player_Managment>().HP = 100;
            Instantiate(heatSigP1, new Vector3(p1.transform.position.x,21, p1.transform.position.z), Quaternion.Euler(0, 0, 0));
        }
        if(p1Score >= 10 || p2Score >= 10)
        {
            Destroy(p1);
            Destroy(p2);
            heatCam.SetActive(true);
        }
    }
}
