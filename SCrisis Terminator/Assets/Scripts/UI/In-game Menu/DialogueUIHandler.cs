using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the dialogue box being shown when interacting
/// </summary>
public class DialogueUIHandler : MonoBehaviour
{
    [SerializeField] private DialogueController dialogue;
    private Animator anim;

    // Regular conversation dialogue fields
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI sentenceField;

    // Choice selection fields
    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private Button buttonPrefab;

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
        dialogueCanvas.SetActive(!dialogue.GetChoosingStatus());
        choiceCanvas.SetActive(dialogue.GetChoosingStatus());

        if(choiceCanvas.activeSelf)
        {
            BuildChoiceList();
        }
        else
        {
            nameField.text = dialogue.GetNode().Name;
            sentenceField.text = dialogue.GetNode().Sentence;
        }
    }

    private void DropUI()
    {
        anim.SetBool("IsTalking", false);
    }

    private void BuildChoiceList()
    {
        // In case there are any Buttons lingering from previous interaction
        foreach(Transform t in choiceCanvas.transform)
        {
            Destroy(t.gameObject);
        }
        
        // Create new buttons
        foreach(DialogueElement node in dialogue.GetAllNodes())
        {
            Button choiceButton = Instantiate(buttonPrefab, choiceCanvas.transform);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = node.Sentence;
            choiceButton.onClick.AddListener(() => { dialogue.SelectChoice(node); });
        }
    }

    private void OnDisable()
    {
        dialogue.OnConversationStarted -= RaiseUI;
        dialogue.OnSentenceChanged -= UpdateUI;
        dialogue.OnConversationEnded -= DropUI;
    }
}
