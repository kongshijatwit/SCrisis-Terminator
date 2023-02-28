using UnityEngine;

public class DialogueUIHandler : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        DialogueManager.instance.StartTalking += ShowDialogueBox;
        DialogueManager.instance.StopTalking += HideDialogueBox;
    }

    private void ShowDialogueBox()
    {
        anim.SetBool("IsTalking", true);
    }

    private void HideDialogueBox()
    {
        anim.SetBool("IsTalking", false);
    }

    private void OnDisable()
    {
        DialogueManager.instance.StartTalking -= ShowDialogueBox;
        DialogueManager.instance.StopTalking -= HideDialogueBox;
    }
}
