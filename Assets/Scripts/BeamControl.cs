using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    private string playerName;
    public int playerToTrack;


    void Start()
    {
       playerToTrack = Random.Range(1, 3);
       playerName = string.Concat("Player", playerToTrack.ToString());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1.name.Equals(playerName))
        {
            transform.position = player1.transform.position;
        }
        else if (player2.name.Equals(playerName))
        {
            transform.position = player2.transform.position;
        }
    }

    void ChangePlayer(int playerNum)
    {
        if (playerNum == 1)
        {
            playerToTrack = 2;
            playerName = "Player2";
        }
        else if (playerNum == 2)
        {
            playerToTrack = 1;
            playerName = "Player1";
        }
    }
}
