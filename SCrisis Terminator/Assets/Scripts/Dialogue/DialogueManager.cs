using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<string> dialogueQueue;

    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI sentenceField;

    public event Action StartTalking;
    public event Action StopTalking;

    private void Awake()
    {
        instance = this;
        dialogueQueue = new();
    }

    public void BeginDialogue(Dialogue dialogue)
    {
        StartTalking();
        dialogueQueue.Clear();
        foreach (string s in dialogue.sentences)
        {
            dialogueQueue.Enqueue(s);
        }
        DisplayNextSentence(dialogue.speakerName);
    }

    public void DisplayNextSentence(string name)
    {
        if (dialogueQueue.Count == 0)
        {
            StopTalking();
            return;
        }
        nameField.text = name;
        sentenceField.text = dialogueQueue.Dequeue();
    }
}
