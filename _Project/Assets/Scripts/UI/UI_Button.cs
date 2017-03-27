using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour {
   public Animator animMenu;
   public Animator animCredits;
   public Animator animInstructions;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  //  public void MenuSlideIn()
    //{
      //  animMenu.SetBool("menu", true);
    //}
    //public void MenuSlideOut()
    //{
    //    animMenu.SetBool("menu", false);
    //}
    public void CreditsSlideIn()
    {
        animMenu.SetBool("menu", false);
        animCredits.SetBool("credits", true);
    }
    public void CreditsSlideOut()
    {
        animCredits.SetBool("credits", false);
        animMenu.SetBool("menu", true);
    }
    public void InstructionsSlideIn()
    {
        animMenu.SetBool("menu", false);
        animInstructions.SetBool("Intructions", true);
    }
    public void InstructionsSlideOut()
    {
        animInstructions.SetBool("Intructions", false);
        animMenu.SetBool("menu", true);
    }
}
