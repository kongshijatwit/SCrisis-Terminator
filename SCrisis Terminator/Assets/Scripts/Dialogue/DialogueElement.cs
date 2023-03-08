using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue Node", order = 1)]
public class DialogueElement : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string sentence;
    [SerializeField] private DialogueElement[] children;

    public string Name { get { return name; } }
    public string Sentence { get { return sentence; } }
    public DialogueElement[] Children { get { return children; } }
}
