using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour {


	public GameObject PausedMenuCanvas;
    public GameObject OptionsMenuCanvas;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        this.PausedMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        this.PausedMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Option()
    {
        this.PausedMenuCanvas.SetActive(false);
        this.OptionsMenuCanvas.SetActive(true);
    }

    public void Exit()
    {
        this.PausedMenuCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
