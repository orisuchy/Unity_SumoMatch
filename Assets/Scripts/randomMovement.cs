using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour
{
    public enum movementOptions {JUMP, GLIDE}
    public movementOptions moveOption;
    private float randomWaitingTime;
    private float objWidth;
    private float objheight;
    private Vector3 nextPos;
    private float speed = 6;
    private bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        randomWaitingTime = Random.Range(1, 10);
        objWidth = getObjWidth();
        objheight = getObjHeight();
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
            if (gameObject.transform.position == nextPos) { isMoving = false; }
        }
        if (randomWaitingTime > 0 && !isMoving)
        {
            randomWaitingTime-= Time.deltaTime;
        }
        else if (randomWaitingTime <= 0 && !isMoving)
        {
            float nextX = Random.Range(-12.5f + objWidth/2, 12.5f - objWidth/2);
            float nextY = Random.Range(-12.5f + objheight/2, 12.5f - objheight/2);
            nextPos = new Vector3(nextX, nextY, 0);

            if (moveOption == 0)
            {
                gameObject.transform.position = nextPos;
            }
            else
            {
                //gameObject.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
                //gameObject.transform.position = Vector3.Lerp(transform.position, nextPos, 0.1f);
                isMoving = true;
            }
            randomWaitingTime = Random.Range(1, 10);
        }
        

        
    }

    private float getObjHeight()
    {
        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        return (p2.x - p1.x);
        
    }

    private float getObjWidth()
    {
        var p1 = gameObject.transform.TransformPoint(0, 0, 0);
        var p2 = gameObject.transform.TransformPoint(1, 1, 0);
        return (p2.y - p1.y);
    }
        Vector3 RandomPosition(int r)
    {
        return new Vector3(Random.Range(-r, r), Random.Range(-r, r), 0);
    }

}
