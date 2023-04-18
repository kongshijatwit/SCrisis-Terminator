using UnityEngine;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject backButton;
    private GameObject currentMenu = null;

    public void OnStartClicked()
    {

    }

    public void OnOptionsClicked()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
        backButton.SetActive(true);
        currentMenu = optionMenu;
    }

    public void OnMenuItemClicked(GameObject menuToOpen)
    {
        mainMenu.SetActive(false);
        menuToOpen.SetActive(true);
        backButton.SetActive(true);
        currentMenu = menuToOpen;
    }

    public void OnBackClicked()
    {
        currentMenu.SetActive(false);
        backButton.SetActive(false);
        mainMenu.SetActive(true);
        currentMenu = mainMenu;
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
