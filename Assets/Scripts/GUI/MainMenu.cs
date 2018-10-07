using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float LogoTransitionTime;
    public GameObject Logo;
    public GameObject MenuButtonsContainer;
    public GameObject CreditsMenuCanvas;
    public GameObject OptionsMenuCanvas;


    private void Awake()
    {
        if (this.Logo != null)
        {
            this.StartCoroutine(LogoTransition());
            this.MenuButtonsContainer.SetActive(false);
        }
        else
            this.MenuButtonsContainer.SetActive(true);
    }

    public void StartGame()
    {
        this.MenuButtonsContainer.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Option()
    {
        this.MenuButtonsContainer.SetActive(false);
        this.OptionsMenuCanvas.SetActive(true);
    }

    public void Credit()
    {
        this.MenuButtonsContainer.SetActive(false);
        this.CreditsMenuCanvas.SetActive(true);
    }

    private IEnumerator LogoTransition()
    {
        yield return new WaitForSeconds(this.LogoTransitionTime);

        Destroy(this.Logo);
        this.Logo = null;
        this.MenuButtonsContainer.SetActive(true);
    }
}
