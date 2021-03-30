using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public Text Counter1;
    public Text Counter2;

    public int playerToTrack;

    private string playerName;
    private string currPlayerCounter;
    private float timeCounter = 0;


    void Start()
    {
        playerToTrack = Random.Range(1, 3);
        playerName = string.Concat("Player", playerToTrack.ToString());
        currPlayerCounter = string.Concat("Counter", playerToTrack.ToString());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1.name.Equals(playerName))
        {
            transform.position = player1.transform.position;
            timeCounter += Time.deltaTime;
            Counter1.text = "Keep Holding the beam:\n" + System.Math.Round(timeCounter).ToString();
            Counter2.text = "";
        }
        else if (player2.name.Equals(playerName))
        {
            transform.position = player2.transform.position;
            timeCounter += Time.deltaTime;
            Counter2.text = "Keep Holding the beam:\n" + System.Math.Round(timeCounter).ToString();
            Counter1.text = "";
        }

       
    }

    void ChangePlayer(int playerNum)
    {
        if (playerNum == 1)
        {
            playerToTrack = 2;
            playerName = "Player2";
            currPlayerCounter = "Counter2";
        }
        else if (playerNum == 2)
        {
            playerToTrack = 1;
            playerName = "Player1";
            currPlayerCounter = "Counter1";

        }
        timeCounter = 0;
    }
}
