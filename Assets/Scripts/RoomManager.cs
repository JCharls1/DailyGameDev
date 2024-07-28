using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject VirtualCam;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player" && !col.isTrigger){
            Debug.Log("Enter");
            VirtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Player" && !col.isTrigger){
            VirtualCam.SetActive(false);
        }
    }
}
