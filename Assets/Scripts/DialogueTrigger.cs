using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {

        GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>().StartDialogue(dialogue);
        //Debug.Log(FindObjectOfType<DialogueManager>().dialogueText!=null);
        //Debug.Log("------------");
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //GetComponent<DialogueManager>().StartDialogue(dialogue);
    }
}
