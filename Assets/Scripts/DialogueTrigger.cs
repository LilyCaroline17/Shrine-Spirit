using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager mangager;

    public void Start()
    {
        mangager = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>();
    }
    public void TriggerDialogue()
    {
        if (mangager == null)
        {
            mangager = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>();
        }
        mangager.StartDialogue(dialogue);
        //Debug.Log(FindObjectOfType<DialogueManager>().dialogueText!=null);
        //Debug.Log("------------");
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //GetComponent<DialogueManager>().StartDialogue(dialogue);
    }
    public void NextSentence()
    {
        mangager.DisplayNextSentence();
    }
}
