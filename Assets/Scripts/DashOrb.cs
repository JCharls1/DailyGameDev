using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashOrb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name);
        Debug.Log("shit");
        Movement.setCanDash(true);
        Debug.Log("12");
        Destroy(gameObject);
    }
}
