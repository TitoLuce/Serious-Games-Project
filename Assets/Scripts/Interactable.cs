using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public enum InteractionType { NONE,Talk,Start}
    public InteractionType type;
    public Dialogue dialogue;

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Talk:
                if(dialogue==null)
                {
                    Debug.Log("Null dialogue.");
                }
                else
                {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
                
                Debug.Log("Interacted");
                break;
            case InteractionType.Start:
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Here");
    }
}
