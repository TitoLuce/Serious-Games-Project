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
        Karl1,
        Ivori1,
        Ming1,
        Kleon1,
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
            case CharacterDialogue.Karl1:
                string localName = "Karl";
                Monologue response1 = new Monologue(localName, "That's pog");
                Monologue response2 = new Monologue(localName, "That's sadge :(");

                Choices c = new Choices(localName, "Eres Eyún Venlen, vas camino a tu trabajo en otro dia de tu rutina, es algo monótona, pero haber buscado tanto trabajo te hace apreciar este, no por la labor como tal, después de todo eres un simple palomero, sino por la compañía, el ambiente en tu oficina es lo mejor, te da un poco de alegría en tu dia.\r\n", ChoiceList(Choice("Fine", response1), Choice("Not fine", response2)));
                Monologue b = new Monologue("Eyun", "¡Buenos días, come piedras!", c);
                Monologue a = new Monologue(localName, "¡Buenos días, abraza árboles!", b);
                return a;
            case CharacterDialogue.Ivori1:
                localName = "Ivori";
                response1 = new Monologue(localName, "That's pog");
                response2 = new Monologue(localName, "That's sadge :(");

                Choices ivoriC = new Choices(localName, "How are you doing my little pog champ?", ChoiceList(Choice("Fine", response1), Choice("Not fine", response2)));
                Monologue ivoriB = new Monologue("Eyun", "Greetings, stone lover.", ivoriC);
                Monologue ivoriA = new Monologue("Karl", "Rock and Stone Leaf Lover", ivoriB);
                return ivoriA;
            case CharacterDialogue.Ming1:
                return null;
            case CharacterDialogue.Kleon1:
                return null;
            default:
                return null;
        }
        
    }
}
