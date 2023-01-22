using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public enum InteractionType { NONE, Talk, Start, Cutscene1 }
    public InteractionType type;
    [HideInInspector] public Dialogue dialogue;
    public GameObject sceneManag;
    private SceneManaguer manager;
    public enum CharacterDialogue
    {
        Eyun,
        Karl1,
        Ivori1,
        Ming1,
        Kleon1,
        Chair,
    }


    public CharacterDialogue chosenDialogue;

    private void Start()
    {
        manager = sceneManag.GetComponent<SceneManaguer>();

    }

    public void Interact()
    {
        switch (type)
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
            case InteractionType.Cutscene1:
                FindObjectOfType<DialogueManager>().StartDialogue(Cutscene());
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
                string playerName = "Eyun";
                Monologue e = new Monologue(localName, "Tengo una corazonada hoy, come hierbas, Jaja-Jaja. Venga a trabajar.");
                Monologue d = new Monologue(localName, "Bah, te pillo hoy la cobardia, hay que vivir la vida amigo mio. A trabajar anda.");

                Monologue response1 = new Monologue(playerName, "Seguro? He ganado las últimas 3 veces, yo no me la juagria mas... Pero por mi adelante!", e);
                Monologue response2 = new Monologue(playerName, "No creo, No estoy de humor hoy. Ádemas, ya he ganado varias veces seguidas compañero, no te conviene", d);

                Choices cChoice = new Choices(localName, "¿hoy también te apuestas 2 cervezas a que preparo y envío mas palomas que tú? Hoy si que sera el dia en que recupere mi racha!", ChoiceList(Choice("Seguro?", response1), Choice("No creo, No estoy de humor hoy.", response2)));
                Monologue b = new Monologue(playerName, "¡Buenos días, come piedras!", cChoice);
                Monologue a = new Monologue(localName, "¡Buenos días, abraza árboles!", b);
                return a;
            case CharacterDialogue.Ivori1:
                localName = "Ivori";
                playerName = "Eyun";

                d = new Monologue(localName, "Me encanta veros sonreir, que ya os amarga suficiente la monotonía. A darlo todo hoy eh? :P");
                e = new Monologue(localName, "nah, no se de que hablas, pero, ahora que lo mencionas, necesito irme ya, me pidieron ordenar los correos de las palomas y voy tarde, nos vemooooos!");
                response1 = new Monologue(playerName, "Jajaja, Lo mismo digo, siempre sabes hacernos reir eh?",d);
                response2 = new Monologue(playerName, "Se sobre tu relacion con el trabajo, recuerda decir que se puedes no tienes tiempo para tomar algunas tareas, eh?", e);

                cChoice = new Choices(localName, "La emoción no es por trabajar, te lo aseguro ;)", ChoiceList(Choice("Lo mismo digo.", response1), Choice("Se sobre tu relacion con el trabajo", response2)));
                b = new Monologue(playerName, "Que emoción por la mañana como siempre, buenos días.", cChoice);
                a = new Monologue(localName, "Buenos diaaaaas!!! :D", b);
                return a;
            case CharacterDialogue.Ming1:
                localName = "Ming";
                playerName = "Eyun";

                d = new Monologue(localName, "Y aun después de ese día seguiré aquí querido. Que te vaya bien en tu trabajo");
                e = new Monologue(localName, "Tonterias querido, ademas, me tomo mis descansos muy enserio, ves ya a trabajar querido... pero muchas gracias por preocuparte por mi.");
                response1 = new Monologue(playerName, "Simplemente tenga cuidado, tantos años en la empresa tienen que empezar a pesar algun dia", d);
                response2 = new Monologue(playerName, "Si usted lo dice..., Pero no me apeteceria que la siguiente vez que la fuera a ver sea en un hospital por no saber descansar.", e);

                cChoice = new Choices(localName, "Gracias por preguntar querido, pero no tienes de que preocuparte, soy bastante resistente… y cabezota! Jaja.", ChoiceList(Choice("Simplemente tenga cuidado.", response1), Choice("Si usted lo dice...", response2)));
                b = new Monologue(playerName, " Buenos días señorita, ¿está mejor? Ayer parecía agotada.", cChoice);
                a = new Monologue(localName, "Buenos días estimado compañero", b);
                return a;
            case CharacterDialogue.Kleon1:
                return null;
            case CharacterDialogue.Chair:
                //localName = "Karl";
                //playerName = "Eyun";

                //response1 = new Monologue(playerName, "");
                //response2 = new Monologue(playerName, "Ok");

                //cChoice = new Choices(localName, "¿Deseas empezar tu jornada laboral?", ChoiceList(Choice("Si", response1), Choice("No", response2)));


                return null; // cChoice;
            default:
                return null;
        }

    }

    private DialogueSection Cutscene()
    {

        

        Monologue response1 = new Monologue("", "Ok");
        Monologue response2 = new Monologue("", "");

        Choices cChoice = new Choices("", "¿Deseas empezar tu jornada laboral?", ChoiceList(Choice("Si", response1), Choice("No", response2)));

        
        manager.startCutscene1 = true;
        

        return cChoice;


    }


}

