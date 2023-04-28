using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshPro dialogueText;
    public Animator animator;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        print("HERE");
        animator.SetBool("talking", true);
        //if (sentences==null) sentences= new Queue<string>();
        sentences.Clear();

        //GameObject vistor = GameObject.FindGameObjectWithTag("visitor");
        //dialogueText = vistor.GetComponentInChildren<TextMeshProUGUI>();
        //animator = vistor.GetComponent<Animator>();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        //Debug.Log(sentences == null);
        if (sentences.Count == 0)
        {
            EndDialogue();
            //Debug.Log("ended");
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //Debug.Log("end of conversation");

        animator.SetBool("talking", false);
    }

}
