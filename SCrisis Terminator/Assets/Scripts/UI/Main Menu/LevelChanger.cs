using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour //Consider renaming to SceneChanger or SceneManager
{
    [SerializeField] Button changeScene;
    [SerializeField] private string levelToLoad;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Set a listener to the start button to begin fade animation
        changeScene.onClick.AddListener(() => { BeginFade(); });
    }

    // Triggers Fadeout animations
    public void BeginFade() => animator.SetTrigger("Fade out");

    public void OnFadeComplete() => SceneManager.LoadScene(levelToLoad);
}
