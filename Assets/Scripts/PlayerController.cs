using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int numOfPickups;
    public Text countText;
    public Text dizzyTimer;
    public Text speedBoostTimer;
    public Text winText;
    public float speed;
    private Rigidbody2D rb2d;
    //private Rigidbody2D rb2dp2;
    private int score;
    private float timeBoost=10;
    private bool activeBoost=false;
    private float timeDizzy=10;
    private bool activeDizzy=false;
    public string horiz="Horizontal";
    public string ver="Vertical";
    private Vector2 movement;
    private Vector3 nextPos;
    public GameObject beam;
    private bool beamHolder;

    
    void Start(){
        rb2d=GetComponent<Rigidbody2D>();
        //rb2dp2=GetComponent<Rigidbody2D>();
        score=0;
        winText.text="";
        dizzyTimer.text = "";
        speedBoostTimer.text = "";
        SetCountText();
        //problems here
        int v = gameObject.name.CompareTo(string.Concat("Player", beam.GetComponents<BeamControl>().playerToTrack));

    }
    void FixedUpdate(){
        //"Horizontal",,,"Vertical"
        float moveHorizontal=Input.GetAxis(horiz);
        float moveVertical=Input.GetAxis(ver);
        movement=new Vector2(moveHorizontal,moveVertical);
        if(activeBoost){
            if(timeBoost>0){
                timeBoost-= Time.deltaTime;
                speedBoostTimer.text = "End of speed boost: " + System.Math.Round(timeBoost).ToString();
            }
            else{
                speed /= 7;
                activeBoost =false;
                timeBoost=10;
                speedBoostTimer.text = "";
            }
            
        }
        if(activeDizzy){
            if(timeDizzy>0){
                timeDizzy-= Time.deltaTime;
                dizzyTimer.text = "End of dizzy: " + System.Math.Round(timeDizzy).ToString();
            }
            else{
                speed = -speed;
                activeDizzy =false;
                timeDizzy=10;
                dizzyTimer.text = "";
            }
            
        }
        rb2d.AddForce(movement*speed);
       // rb2d.AddForce(new Vector2(0,0));
        if(Input.GetKey("escape")){
            Application.Quit();
        }

    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            score++;
            numOfPickups--;
            SetCountText();
        }
        else if(other.gameObject.CompareTag("SpeedBoost")){
            other.gameObject.SetActive(false);
            speed = speed * 7;
            activeBoost=true;
            
        }
        else if(other.gameObject.CompareTag("Saw")){
            score -= 2;
            SetCountText();
            if(!activeDizzy){
                speed=-speed;
                activeDizzy=true;
            }
            
        }
        else if(other.gameObject.CompareTag("Background")){
            score-=2;
            SetCountText();
            nextPos = new Vector3(Random.Range(-7,7) , Random.Range(-7, 7), 0);

            gameObject.transform.position = nextPos;
            rb2d.AddForce(new Vector2(0, 0));
        }
        else if(other.gameObject.CompareTag("Player")){
            
            var magnitude = 1000;
            var force = transform.position-other.transform.position;
            force.Normalize ();
            rb2d.AddForce (-force * magnitude);
            
        }

    }
    void SetCountText(){
        countText.text="Score: "+score.ToString();
        if(numOfPickups == 0)
        {
            winText.text="You won!!\nYour score is " + score.ToString();
        }
    }    
}
