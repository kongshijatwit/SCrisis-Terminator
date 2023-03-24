using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int peopleSpokenTo;

    private void Awake() 
    {
        instance = this;
    }
}
