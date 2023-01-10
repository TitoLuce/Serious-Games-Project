using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueText;
    public Canvas dialogueCanvas;

    private Queue<string> sentences;
    [HideInInspector] public bool dialogueActive;
    
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueCanvas.enabled = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueActive= true;
        dialogueCanvas.enabled = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence=sentences.Dequeue();

        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        dialogueActive= false;
        dialogueText.text = "";
        dialogueCanvas.enabled = false;
        Debug.Log("Conversation end.");
    }
}
