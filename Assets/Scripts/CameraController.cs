using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player2;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position-(Player.transform.position+Player2.transform.position)/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      //  transform.position=(Player.transform.position+Player2.transform.position)/2+offset;
    }
}
