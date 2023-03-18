using UnityEngine;

/// <summary>
/// ScriptableObject for creating dialogue nodes
/// Think of it as a tree data structure
/// </summary>
[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue Node", order = 1)]
public class DialogueElement : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string sentence;
    [SerializeField] private DialogueElement[] children;

    public string Name { get { return name; } }
    public string Sentence { get { return sentence; } set { sentence = value; } }
    public DialogueElement[] Children { get { return children; } }

    public void Init(string name, string sentence, DialogueElement[] children)
    {
        this.name = name;
        this.sentence = sentence;
        this.children = children;
    }
}
