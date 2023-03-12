using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIHandler : MonoBehaviour
{
    [SerializeField] private DialogueController dialogue;
    private Animator anim;

    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI sentenceField;

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
        foreach(Transform t in choiceCanvas.transform)
        {
            Destroy(t.gameObject);
        }
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
