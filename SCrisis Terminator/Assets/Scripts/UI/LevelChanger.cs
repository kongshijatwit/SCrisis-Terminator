using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Button startButton;
    private Animator animator;
    private string levelToLoad;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Finds Start button and set listner to begin Fade Animations
        startButton.onClick.AddListener(() => { FadeToLevel("World"); });
    }

    // Triggers Fade out animations
    public void FadeToLevel(string world)
    {
        levelToLoad = world;
        animator.SetTrigger("Fade out");
    }

    // Loads next level after fade has ended
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
