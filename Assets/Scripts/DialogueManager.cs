using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Dialogue;

public class DialogueManager : MonoBehaviour
{
    public DialogueSection currentSection;

    [Header("Text Components")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentsText;

    [Header("Dialogue choice")]
    public GameObject dialogueChoiceObject;
    public Transform parentChoicesTo;

    [Header("Animation")]
    public Animator animator;
    public CanvasGroup dialogueCanvasGroup;

    public bool optionsDisplayed;

    public Image characterImage;
    public Sprite[] images;

    private void Start()
    {
        InitializePanel();
        characterImage.enabled = false;
    }

    private void InitializePanel()
    {
        animator.SetBool("ChatOpen", false);
    }

    private void Update()
    {
        PrepareForOptionDisplay();
        DisplayDialogueOptions();
        optionsDisplayed = optionsBeenDisplayed;
    }

    private void UpdatePanel()
    {
        animator.SetBool("ChatOpen", !animator.GetBool("ChatOpen"));
    }

    private void PrepareForOptionDisplay()
    {
        if (optionsBeenDisplayed)
        {
            return;
        }
        if (typeof(Choices).IsInstanceOfType(currentSection))
        {
            ResetDisplayOptionsFlags();
        }
    }

    public void StartDialogue(DialogueSection start)
    {
        UpdatePanel();
        ClearAllOptions();
        currentSection = start;
        DisplayDialogue();
    }

    public void ProceedToNext()
    {
        if(displayingChoices)
        {
            return;
        }
        if (currentSection.GetSection() != null)
        {
            currentSection = currentSection.GetSection();
            DisplayDialogue();
        }
        else { EndDialogue(); }
    }

    public void DisplayDialogue()
    {
        if (currentSection == null)
        {
            EndDialogue();
            return;
        }
        bool isMonologue = typeof(Monologue).IsInstanceOfType(currentSection);

        ClearAllOptions();
        DisplayText();
    }

    private void DisplayText()
    {
        optionsBeenDisplayed = false;
        nameText.text = currentSection.GetSpeakerName();
        if (currentSection.GetSpeakerName() == "Eyun")
        {
            characterImage.enabled = true;
            characterImage.sprite = images[0];
        }
        else if (currentSection.GetSpeakerName() == "Karl")
        {
            characterImage.enabled = true;
            characterImage.sprite = images[1];
        }
        else if (currentSection.GetSpeakerName() == "Ming")
        {
            characterImage.enabled = true;
            characterImage.sprite = images[2];
        }
        else if (currentSection.GetSpeakerName() == "Kleon")
        {
            characterImage.enabled = true;
            characterImage.sprite = images[3];
        }
        else if (currentSection.GetSpeakerName() == "Ivori")
        {
            characterImage.enabled = true;
            characterImage.sprite = images[4];
        }
        else 
        { characterImage.sprite = null;
            characterImage.enabled = false;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSection.GetSpeechContents()));
    }

    private void EndDialogue()
    {
        UpdatePanel();
        nameText.text = "";
        contentsText.text = "";
        ClearAllOptions();
        characterImage.enabled = false;
        Debug.Log("Conversation end.");
    }

    private void ClearAllOptions()
    {
        GameObject[] currentDialogueOptions = GameObject.FindGameObjectsWithTag("DialogueChoice");
        foreach(var entry in currentDialogueOptions)
        {
            Destroy(entry);
        }
    }

    int indexOfCurrentChoice = 0;

    [HideInInspector] public bool displayingChoices;
    private bool optionsBeenDisplayed;

    public void ResetDisplayOptionsFlags()
    {
        optionsBeenDisplayed = true;
        displayingChoices = true;
        indexOfCurrentChoice = 0;
    }

    public void DisplayDialogueOptions()
    {
        if(!typeof(Choices).IsInstanceOfType(currentSection))
        {
            return;
        }

        Choices choices = (Choices)currentSection;

        if(displayingChoices)
        {
            if(indexOfCurrentChoice<choices.choices.Count)
            {
                Tuple<string, DialogueSection> option = choices.choices[indexOfCurrentChoice];

                GameObject s = Instantiate(dialogueChoiceObject, Vector3.zero, Quaternion.identity);
                s.transform.SetParent(parentChoicesTo);
                s.GetComponent<RectTransform>().localScale = Vector3.one;

                DialogueOptionDisplay optionDisplayBehavior = s.GetComponent<DialogueOptionDisplay>();

                optionDisplayBehavior.SetDisplay(option.Item1, option.Item2);
                indexOfCurrentChoice++;
            }
            else
            {
                displayingChoices = false;
            }
        }
    }

    //public TMPro.TMP_Text nameText;
    //public TMPro.TMP_Text dialogueText;
    //public Canvas dialogueCanvas;
    //public Animator animator;

    //private Queue<string> sentences;

    //private void Start()
    //{
    //    sentences = new Queue<string>();
    //}

    //public void StartDialogue(Dialogue dialogue)
    //{
    //    animator.SetBool("ChatOpen", true);
    //    dialogueCanvas.enabled = true;
    //    nameText.text = dialogue.name;

    //    sentences.Clear();

    //    foreach(string sentence in dialogue.sentences)
    //    {
    //        sentences.Enqueue(sentence);
    //    }
    //    DisplayNextSentence();
    //}

    //public void DisplayNextSentence()
    //{
    //    if(sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }
    //    string sentence = sentences.Dequeue();

    //    //dialogueText.text = sentence;
    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(sentence));
    //}



    IEnumerator TypeSentence(string sentence)
    {
        contentsText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            contentsText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

    }
}
