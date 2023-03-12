using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    public Button startButton;
    public Animator animator;
    // var takes string value and loads it into next level
    private string levelToLoad;

    //Start is called before the first frame update
    void Start()
    {
        //Finds Start button and set listner to begin Fade Animations
        startButton.onClick.AddListener( delegate {FadeToLevel("World"); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggers Fadeout animations
   public void FadeToLevel (string World) {
        levelToLoad = World;
        animator.SetTrigger("Fade out");
    }
    //loads next level after fade has ended
    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
