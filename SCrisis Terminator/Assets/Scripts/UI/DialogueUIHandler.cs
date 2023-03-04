using UnityEngine;
using TMPro;

public class DialogueUIHandler : MonoBehaviour
{
    private Animator anim;
    public DialogueController dialogue;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI sentenceField;

    private void Awake()
    {
        dialogue.OnConversationStarted += RaiseUI;
        dialogue.OnSentenceChanged += UpdateUI;
        dialogue.OnConversationEnded += DropUI;
    }

    private void Start() => anim = GetComponent<Animator>();

    private void RaiseUI()
    {
        anim.SetBool("IsTalking", true);
        UpdateUI();
    }

    private void UpdateUI()
    {
        nameField.text = dialogue.GetName();
        sentenceField.text = dialogue.GetCurrentSentence();
    }

    private void DropUI()
    {
        anim.SetBool("IsTalking", false);
    }

    private void OnDisable()
    {
        dialogue.OnConversationStarted -= RaiseUI;
        dialogue.OnSentenceChanged -= UpdateUI;
        dialogue.OnConversationEnded -= DropUI;
    }
}
