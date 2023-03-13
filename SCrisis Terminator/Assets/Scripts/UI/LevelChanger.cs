using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] Button startButton;
    private Animator animator;
    private string levelToLoad;

    //Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // Set a listener to the start button to begin fade animation
        startButton.onClick.AddListener(() => { FadeToLevel("World"); });
    }

    // Triggers Fadeout animations
    public void FadeToLevel(string world) 
    {
        levelToLoad = world;
        animator.SetTrigger("Fade out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
