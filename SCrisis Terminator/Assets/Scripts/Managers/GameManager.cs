using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int peopleSpokenTo;
    public int informationGathered;

    private void Awake() 
    {
        instance = this;
    }
}
