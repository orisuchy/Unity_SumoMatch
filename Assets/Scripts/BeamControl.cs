using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerToTrack;
    void Start()
    {
        playerToTrack = Random.Range(1, 3);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
