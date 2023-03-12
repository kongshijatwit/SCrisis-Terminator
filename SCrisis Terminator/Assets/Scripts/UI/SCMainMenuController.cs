using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCMainMenuController : MonoBehaviour
{
    public GameObject Yes;
    public GameObject No;
    public GameObject Back;
    public GameObject URL;
    public GameObject TutorialButton;
    public GameObject HubButton;
    public GameObject Quit;
    public GameObject StartButton;
    // Start is called before the first frame update
    void Start() {
    
        

    }

    // Enables tracking
    public void YesButtonClick()
    {
         SceneManager.LoadScene("LoginTracker");
    }

    // Click Function to exit
    public void QuitButtonClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
    

    }
}
