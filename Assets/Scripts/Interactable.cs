using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using static Dialogue;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public enum InteractionType { NONE, Talk, Start, Cutscene1, Cutscene2}
    public InteractionType type;
    [HideInInspector] public Dialogue dialogue;



    public enum CharacterDialogue
    {
        Eyun,
        Karl1,
        Karl2,
        Ivori1,
        Ivori2,
        Ming1,
        Ming2,
        Kleon1,
        Chair,
        Exit,
    }


    public CharacterDialogue chosenDialogue;

    private void Start()
    {
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
            case InteractionType.Cutscene2:
                FindObjectOfType<DialogueManager>().StartDialogue(Cutscene2());
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
            case CharacterDialogue.Karl2:
                localName = "Karl";
                playerName = "Eyun";

                d = new Monologue(playerName, "Kaaaaaarl!!");
                b = new Monologue(localName, "NOOOOOOOOOOOOOOOOOOOOOO", d);
                a = new Monologue(localName, "Despues de todo lo que he hecho!!", b);
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
            case CharacterDialogue.Ming2:
                localName = "Ming";
                playerName = "Eyun";

                d = new Monologue(localName, "Desde que ha cambiado el director todo esta yendo a peor...");
                b = new Monologue(playerName, "Que acaba de suceder?", d);
                a = new Monologue(localName, "No... El buen Karl...", b);
                return a;
            case CharacterDialogue.Ivori2:
                localName = "Ivori";
                playerName = "Eyun";

                a = new Monologue(localName, "No puedo hablar ahora mismo, hay demasiadas palomas mensajeras que atender!!");
                return a;
            case CharacterDialogue.Kleon1:
                localName = "Kleon";
                playerName = "Eyun";

                d = new Monologue(localName, "Karl se tendrá que ir de la empresa, alegraos los demas pues estareis a cargo de su parte.");
                b = new Monologue(localName, "Me complace gratamente decirles que a partir de hoy...", d);
                a = new Monologue(localName, "Buenas tardes queridos...trabajadores", b);
                return a;
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

        return cChoice;
    }

    private DialogueSection Cutscene2()
    {
        Monologue response1 = new Monologue("", "Ok2");
        Monologue response2 = new Monologue("", "");

        Choices cChoice = new Choices("", "¿Deseas acabar tu jornada laboral?", ChoiceList(Choice("Si", response1), Choice("No", response2)));

        return cChoice;
    }


}

