using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {


    public GameObject OptionsMenuCanvas;
    public GameObject PausedMenuCanvas;


    // Use this for initialization
    public void Start ()
    {

        this.OptionsMenuCanvas.SetActive(true);

    }




    public void Back()
    {
        this.OptionsMenuCanvas.SetActive(false);
        this.PausedMenuCanvas.SetActive(true);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
