using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tutorialText;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMove.tutorial==true)
        {text.SetActive(true);}
        else{text.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.tutorial==true&&PlayerMove.learn==0)
        {tutorialText.text="Press WSAD key to move to a different room.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==1)
        {tutorialText.text="Move Mouse to rotate.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==2)
        {tutorialText.text="Right click to open and close flashlight.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==3)
        {tutorialText.text="Left click to close door.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==4)
        {tutorialText.text="Left click on the seal to seal the demon.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==5)
        {tutorialText.text="Wait for the sealing.";}
        if(PlayerMove.tutorial==true&&PlayerMove.learn==6)
        {tutorialText.text="Seal all the demon to win the game.";}    
    }
}
