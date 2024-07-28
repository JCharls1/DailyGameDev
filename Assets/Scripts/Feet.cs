using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
     // Specify the layer you want to trigger
    public string targetLayerName;

    private int targetLayer;

    [SerializeField] public GameObject targetObject;

    void Start()
    {
        // Convert the layer name to its corresponding layer number
        targetLayer = LayerMask.NameToLayer(targetLayerName);
    }

    // This method is called when the collider other enters the trigger
    void OnTriggerStay2D(Collider2D other)
    {
        Movement script = targetObject.GetComponent<Movement>();
        // Check if the other GameObject's layer matches the target layer
        if (other.gameObject.layer == targetLayer)
        {
            
            script.enabled = true;
            Movement.isGrouded = true;
            Movement.canDash = true;
        }
    }
}
