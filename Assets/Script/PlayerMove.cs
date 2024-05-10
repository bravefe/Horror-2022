using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Seal seal1; 
    public Seal seal2; 
    public Seal seal3; 
    public Seal seal4;
    
    public static bool tutorial = false;
    public static int learn = 0;

    public GameObject WinPanel;
    public GameObject FlashLight;
    private bool lightOn = false;

    public static int flashLightCount = 0;
    public static int playerMoveCount = 0;

    public Image Battery;
    public float batteryLast = 1f;
    public bool batteryRanOut = false;

    public Door door0;
    public Door door1;
    public Door door2;
    public Door door3;
    public Door door4;
    public Door door5;
    public Door door6;
    public Door door7;
    public Door door8;
    public Door door9;
    public Door door10;
    public Door door11;

    void Awake()
    {
        if(Menu.level1==2&&Menu.speed1==1)
        {tutorial=true;}
        else{tutorial=false;}
    }

    void Update()
    {
        Light();
        if (seal1.sealing == false && seal2.sealing == false && seal3.sealing == false && seal4.sealing == false && PlayerView.gameStop == false) {Move();}
        if (seal1.wasSeal == true && seal2.wasSeal == true && seal3.wasSeal == true && seal4.wasSeal == true) 
        {
            WinPanel.SetActive(true); StartCoroutine(Wait(5f));
            CheckLevel(0,2,1);
            CheckLevel(1,3,1);
            CheckLevel(2,3,2);
            CheckLevel(3,5,1);
            CheckLevel(4,4,2);
            CheckLevel(5,6,1);
            CheckLevel(6,2,3);
            CheckLevel(7,6,2);
            CheckLevel(8,6,3);
            PlayerPrefs.SetInt("Level", Menu.levelPass);
            PlayerPrefs.Save();
        }
    }
    void CheckLevel(int a,int b,int c)
    {
        if(Menu.levelPass==a&&Menu.level1==b&&Menu.speed1==c)
        {Menu.levelPass+=1;}
    }

    public IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Menu"); 
    }

    public float xPosition = 10f;
    public float zPosition = -10f;

    private void Move()
    {
        if (Input.GetKeyDown("w"))
        {
            if(PlayerView.playerFacing == 0){Forward();}
            if(PlayerView.playerFacing == 1){Right();}
            if(PlayerView.playerFacing == 2){Backward();}
            if(PlayerView.playerFacing == 3){Left();}
            OpenAllDoor();
            playerMoveCount+=1;
        }
        if (Input.GetKeyDown("s"))
        {
            if(PlayerView.playerFacing == 0){Backward();}
            if(PlayerView.playerFacing == 1){Left();}
            if(PlayerView.playerFacing == 2){Forward();}
            if(PlayerView.playerFacing == 3){Right();}
            OpenAllDoor();
            playerMoveCount+=1;
        }
        if (Input.GetKeyDown("d"))
        {
            if(PlayerView.playerFacing == 0){Right();}
            if(PlayerView.playerFacing == 1){Backward();}
            if(PlayerView.playerFacing == 2){Left();}
            if(PlayerView.playerFacing == 3){Forward();}
            OpenAllDoor();
            playerMoveCount+=1;
        }
        if (Input.GetKeyDown("a"))
        {
            if(PlayerView.playerFacing == 0){Left();}
            if(PlayerView.playerFacing == 1){Forward();}
            if(PlayerView.playerFacing == 2){Right();}
            if(PlayerView.playerFacing == 3){Backward();}   
            OpenAllDoor();
            playerMoveCount+=1;
        }
    }

    private void Light()
    {
        if(Input.GetKeyDown("f")&&batteryRanOut==false&&PlayerView.gameStop == false
        ||Input.GetMouseButtonDown(1)&&batteryRanOut==false&&PlayerView.gameStop == false)
        {
            if(tutorial==true&&learn==2)
            {learn+=1;}
            FindObjectOfType<AudioManager>().Play("Light");
            if(lightOn==false){FlashLight.SetActive(true);lightOn=true;flashLightCount+=1;}
            else if(lightOn==true){FlashLight.SetActive(false);lightOn=false;}
        }
        if(lightOn==true&&PlayerView.gameStop == false)
        {
            Battery.fillAmount -= 1 / batteryLast * Time.deltaTime;
        }
        if (Battery.fillAmount <= 0 && batteryRanOut == false)
        {
            FlashLight.SetActive(false);lightOn=false;
            FindObjectOfType<AudioManager>().Play("Light");
            batteryRanOut=true;
        }          
    }

    private void Forward() {if (zPosition < 0){zPosition += 10; transform.position = new Vector3 (xPosition, 1, zPosition);}}
    private void Backward() {if (zPosition > -20){zPosition -= 10;transform.position = new Vector3 (xPosition, 1, zPosition);}}
    private void Right() {if (xPosition < 20){xPosition += 10;transform.position = new Vector3 (xPosition, 1, zPosition);}}
    private void Left() {if (xPosition > 0){xPosition -= 10;transform.position = new Vector3 (xPosition, 1, zPosition);}}

    private void OpenAllDoor()
    {
        if(tutorial==true&&learn==0)
        {learn+=1;}
        door0.doorClosed=false;
        door1.doorClosed=false;
        door2.doorClosed=false;
        door3.doorClosed=false;
        door4.doorClosed=false;
        door5.doorClosed=false;
        door6.doorClosed=false;
        door7.doorClosed=false;
        door8.doorClosed=false;
        door9.doorClosed=false;
        door10.doorClosed=false;
        door11.doorClosed=false;
    }
}
