using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                if(!FindObjectOfType<DialogueManager>().dialogueActive)
                {
                    detectedObject.GetComponent<Interactable>().Interact();
                    Debug.Log("Interact");
                }
                else
                {
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                }
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    bool Detect()
    {
        
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
