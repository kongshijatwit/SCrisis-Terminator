[System.Serializable]
public class DialogueElement
{
    [UnityEngine.SerializeField] private string name;
    [UnityEngine.SerializeField] private string sentence;

    public string Name { get { return name; } }
    public string Sentence { get { return sentence; } }
}
