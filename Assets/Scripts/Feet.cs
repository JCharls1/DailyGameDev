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
            // Add your logic here for when the target layer enters the trigger
            Debug.Log("Target layer entered the trigger: " + other.gameObject.name);
            
            script.enabled = true;
            Debug.Log("ScriptToDisable has been enabled.");
            Movement.isGrouded = true;
            Movement.canDash = true;
        }
    }
}
