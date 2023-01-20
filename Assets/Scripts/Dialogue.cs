using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Dialogue : MonoBehaviour
{
    //public string name;
    //[TextArea(3,10)]
    //public string[] sentences;
    public interface DialogueSection
    {
        string GetSpeakerName();
        string GetSpeechContents();
        DialogueSection GetSection();
    }

    public class Monologue: DialogueSection
    {
        public string speakerName;
        public string content;
        public DialogueSection nextDialogue;

        public Monologue(
            string speakerName="Amogus",
            string content= "Sus",
            DialogueSection nextDialogue=null)
        {
            this.speakerName = speakerName;
            this.content = content;
            this.nextDialogue = nextDialogue;
        }

        public DialogueSection GetSection()
        {
            return nextDialogue;
        }

        public string GetSpeakerName()
        {
            return speakerName;
        }

        public string GetSpeechContents()
        {
            return content;
        }
    }

    public class Choices: DialogueSection
    {
        public string speakerName;
        public string contents;
        public List<Tuple<string, DialogueSection>> choices;

        public Choices(
            string speakerName = "Sus",
            string contents = "Amogus",
            List<Tuple<string, DialogueSection>> choices = null)
        {
            this.speakerName = speakerName;
            this.contents = contents;
            this.choices = choices;
        }

        public DialogueSection GetSection()
        {
            return null;
        }

        public string GetSpeakerName()
        {
            return speakerName;
        }

        public string GetSpeechContents()
        {
            return contents;
        }
    }

    public static Tuple<string,DialogueSection> Choice(string choice, DialogueSection nextDialogue)
    {
        return new Tuple<string, DialogueSection>(choice, nextDialogue);
    }

    public static List<Tuple<string,DialogueSection>> ChoiceList(params Tuple<string,DialogueSection>[] entries)
    {
        List<Tuple<string, DialogueSection>> result = new List<Tuple<string, DialogueSection>>();
        foreach(var tuple in entries)
        {
            result.Add(tuple);
        }
        return result;
    }
}
