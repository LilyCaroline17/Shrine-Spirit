using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public string wanted;
    public DialogueManager mangager;

    public void Start()
    {
        mangager = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>();
        string[] lines = { "I wish to meet the love of my life", "I want to ace my written exam", "I hope to find my missing cat", "I wish to go to the festival, but I have chores" };
        string[] token = { "token_love", "token_luck", "token_luck", "token_grow" };
        int index = Random.Range(0, lines.Length);
        dialogue.sentences[0] = lines[index];
        wanted = token[index];
    }
    public void TriggerDialogue()
    {
        //if (mangager == null)
        //{
        //    mangager = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>();
        //}
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
