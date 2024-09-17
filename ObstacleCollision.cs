using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;

    public GameObject levelControl;

    public GameObject mainCam;
    void OnTriggerEnter(Collider other)
    {   
        this.gameObject.GetComponent<BoxCollider>().enabled=false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}