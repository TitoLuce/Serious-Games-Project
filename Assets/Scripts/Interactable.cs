using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public enum InteractionType { NONE,Talk,Start}
    public InteractionType type;
    [HideInInspector] public Dialogue dialogue;

    public enum CharacterDialogue
    {
        Eyun,
        Karl,
        Ivori,
        Ming,
        Kleon
    }
    public CharacterDialogue chosenDialogue;

    private void Start()
    {
        
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Talk:
                //if(dialogue==null)
                //{
                //    Debug.Log("Null dialogue.");
                //}
                //else
                //{
                //    FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
                //}
                FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
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

    private DialogueSection Conversation()
    {
        switch (chosenDialogue)
        {
            case CharacterDialogue.Eyun:
                return null;
            case CharacterDialogue.Karl:
                string localName = "Test";
                Monologue fine = new Monologue(localName, "That's pog");
                Monologue notFine = new Monologue(localName, "That's sadge :(");

                Choices b = new Choices(localName, "How are you doing my little pog champ?", ChoiceList(Choice("Fine", fine), Choice("Not fine", notFine)));
                Monologue a = new Monologue(localName, "Hello.", b);
                return a;
            case CharacterDialogue.Ivori:
                return null;
            case CharacterDialogue.Ming:
                return null;
            case CharacterDialogue.Kleon:
                return null;
            default:
                return null;
        }
        
    }
}
