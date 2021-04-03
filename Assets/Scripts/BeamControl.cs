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
    public Text mainTimer;

    public int playerToTrack;

    private string playerName;
    private string currPlayerCounter;
    private float timeCounter = 0;
    private float gameTimer=90;


    void Start()
    {
        playerToTrack = Random.Range(1, 3);
        playerName = string.Concat("Player", playerToTrack.ToString());
        currPlayerCounter = string.Concat("Counter", playerToTrack.ToString());
        mainTimer.text="";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        mainTimer.text = "Time remaining: " + System.Math.Round(gameTimer).ToString();
        if(gameTimer<0){
            if(player1.GetComponent<PlayerController>().getScore()>player2.GetComponent<PlayerController>().getScore()){
                player1.SendMessage("setWinText", "player1");
            }else{
               player2.SendMessage("setWinText", "player2"); 
            }
        }
        else
        {
            gameTimer -= Time.deltaTime;
        }
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
        if (playerNum == 1 && playerToTrack==1)
        {
            playerToTrack = 2;
            playerName = "Player2";
            currPlayerCounter = "Counter2";
            player1.SendMessage("addCircleScore", System.Math.Round(timeCounter));
            timeCounter = 0;
        }
        else if (playerNum == 2 && playerToTrack==2)
        {
            playerToTrack = 1;
            playerName = "Player1";
            currPlayerCounter = "Counter1";
            player2.SendMessage("addCircleScore", System.Math.Round(timeCounter));
            timeCounter = 0;
        }
        
    }
}
