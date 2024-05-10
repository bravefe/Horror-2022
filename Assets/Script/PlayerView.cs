using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerView : MonoBehaviour
{
    
    public float mouseSensitivity = 3000f;
    public Transform player;
    public float mouseX;
    public static bool gameStop = false;

    public GameObject tipsPanel;
    public GameObject pausePanel;
    public TMP_Text sensitivityText;
    public static float m = 90f;
    private float n;

    public static int playerFacing;
    // public float rotationAngle = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerFacing = 0;
        n=m-101f;
        mouseSensitivity=n*-1;
    }

    public Seal seal1; 
    public Seal seal2; 
    public Seal seal3; 
    public Seal seal4; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {pausePanel.SetActive(true);Cursor.lockState = CursorLockMode.None;gameStop=true;}
        if (Input.GetKeyDown("t"))
        {
            if(gameStop==false) 
            {
                tipsPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                gameStop=true;
            }
            else if(gameStop==true)
            {
                tipsPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                gameStop=false;
            }
        }
        if (seal1.sealing == false && seal2.sealing == false && seal3.sealing == false && seal4.sealing == false && gameStop == false) 
        {Rotate();}

        Mouse();
    }

    public void Plus(){m+=1;}
    public void Mi(){m-=1;}

    public void Quit()
    {
        Application.Quit();
    }

    public void Mouse()
    {
        sensitivityText.text=m.ToString();
        if(m>100){m=100;}
        if(m<0){m=0;}
    }

    public void Back()
    {
        n=m-101f;
        mouseSensitivity=n*-1;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        gameStop=false;
    }
    
    private void Rotate()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime;
        // player.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,rotationAngle,0), 3000*Time.deltaTime);
        // if (playerFacing == 0){rotationAngle = 0;}
        // if (playerFacing == 1){rotationAngle = 90;}
        // if (playerFacing == 2){rotationAngle = 180;}
        // if (playerFacing == 3){rotationAngle = -90;}
        if (mouseX >= mouseSensitivity * 0.01)
        {
            player.Rotate(Vector3.up * 90);
            mouseX = 0;
            playerFacing += 1;
            if (playerFacing >= 4) {playerFacing = 0;}
            if(PlayerMove.tutorial==true&&PlayerMove.learn==1)
            {PlayerMove.learn+=1;}
        } 
        if (mouseX <= mouseSensitivity * -0.01)
        {
            player.Rotate(Vector3.up * -90);
            mouseX = 0;
            playerFacing -= 1;
            if (playerFacing <= -1) {playerFacing = 3;}
            if(PlayerMove.tutorial==true&&PlayerMove.learn==1){PlayerMove.learn+=1;}
        }
    }
}
