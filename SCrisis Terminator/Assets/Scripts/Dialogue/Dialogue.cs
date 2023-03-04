using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [SerializeField] List<DialogueElement> dialogues;
    private int index = 0;

    private void Awake()
    {
        dialogues = new();
        if (dialogues.Count < 1) 
        { dialogues.Add(new()); }
    }

    public DialogueElement GetBeginning()
    {
        index = 0;
        return dialogues[0];
    }

    public DialogueElement GetNext() => index + 1 < dialogues.Count ? dialogues[++index] : null;
}
