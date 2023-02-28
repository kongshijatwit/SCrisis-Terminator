using UnityEngine;

public class NPC : Interactable, IInteractable
{
    [SerializeField] private Dialogue dialogue;
    private bool conversing = false;

    private new void Start()
    {
        base.Start();
        DialogueManager.instance.StopTalking += StopConversing;
    }

    public void Interact()
    {
        if (dialogue.sentences.Length < 1)
        {
            Debug.LogWarning("Sentences length less than 1");
            return;
        }
        if (dialogue.speakerName == "")
        {
            dialogue.speakerName = gameObject.name;
        }
        if (!conversing)
        {
            DialogueManager.instance.BeginDialogue(dialogue);
            conversing = true;
        }
        else
        {
            DialogueManager.instance.DisplayNextSentence(dialogue.speakerName);
        }
    }

    private void StopConversing() => conversing = false;

    private void OnDisable()
    {
        DialogueManager.instance.StopTalking -= StopConversing;
    }
}
