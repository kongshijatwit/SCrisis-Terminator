using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [SerializeField] DialogueElement[] dialogues;
    private int index = 0;

    public DialogueElement GetBeginning()
    {
        index = 0;
        return dialogues[0];
    }

    public DialogueElement GetNext() => index + 1 < dialogues.Length ? dialogues[++index] : null;
}
