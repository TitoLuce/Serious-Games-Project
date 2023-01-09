using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType { NONE,Talk,Start}
    public InteractionType type;

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Talk:
                FindObjectOfType<InteractionSystem>().Chat(gameObject);
                Debug.Log("Interacted");
                break;
            case InteractionType.Start:
                break;
            default:
                break;
        }
    }
}
