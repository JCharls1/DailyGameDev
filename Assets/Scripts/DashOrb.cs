using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashOrb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Movement.setCanDash(true);
        Destroy(gameObject);
    }
}
