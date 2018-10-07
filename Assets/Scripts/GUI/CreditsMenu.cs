using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour {


    public GameObject CreditMenuCanvas;
    public GameObject MenuButtonsContainer;



    public void Back()
    {
        this.CreditMenuCanvas.SetActive(false);
        this.MenuButtonsContainer.SetActive(true);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
