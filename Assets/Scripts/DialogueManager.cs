using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with" + dialogue.visitor);

        //Debug.Log(sentences==null);
        animator.SetBool("talking", true);
        if (sentences==null) sentences= new Queue<string>();
        sentences.Clear();

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
            Debug.Log("ended");
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");

        animator.SetBool("talking", false);
    }

}
