using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius = 0.1f;
    public LayerMask detectionLayer;
    public GameObject detectedObject;

    // Update is called once per frame
    void Update()
    {
        if(Detect())
        {
            if(InteractInput())
            {
                Debug.Log("Interact");
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    bool Detect()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        
    }
    public void Chat(GameObject character)
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
