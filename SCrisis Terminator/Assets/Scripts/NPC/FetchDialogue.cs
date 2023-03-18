using UnityEngine;

public class FetchDialogue : MonoBehaviour, IRaycastable
{
    // Dialogue Attributes
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private DialogueElement rootDialogue;
    private bool isConversing = false;

    // Fetch Quest Attributes
    [SerializeField] private GameObject[] fetchObjects;
    private GameObject givenObject = null;
    private int index = 0;

    // No reason to set a constantly changing Dialogue ScriptableObject in the inspector
    // so we create a Dialogue SO from code only
    private void Start()
    {
        rootDialogue = ScriptableObject.CreateInstance<DialogueElement>();
        rootDialogue.Init(gameObject.name, "", null);
    }

    public void HandleRaycast(PlayerRaycast player)
    {
        if (Input.GetKeyDown(interactionKey))
        {
            var dialogueController = player.GetComponent<DialogueController>();
            givenObject = PickupManager.instance.pickup;
            rootDialogue.Sentence = DetermineSentence();
            if (!isConversing)
            {
                dialogueController.StartDialogue(rootDialogue);
                isConversing = true;
            }
            else
            {
                dialogueController.EndDialogue();
                isConversing = false;
            }
        }
    }

    private string DetermineSentence()
    {
        if (index > fetchObjects.Length - 1)
        {
            return "Thanks for all your help. This will be all I need.";
        }
        else if (givenObject == fetchObjects[index])
        {
            index++;
            return "Thank you for bringing it to me.";
        }
        return $"I need a {fetchObjects[index].name}.";
    }
}
