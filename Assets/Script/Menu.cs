using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject customPanel;
    public GameObject settingPanel;
    public GameObject levelPanel;

    public static int levelPass = 0;

    public static int level1 = 0;
    public static int level2 = 0;
    public static int level3 = 0;
    public static int level4 = 0;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;

    public static float speed1 = 1f;
    public static float speed2 = 1f;
    public static float speed3 = 1f;
    public static float speed4 = 1f;
    public TMP_Text textS1;
    public TMP_Text textS2;
    public TMP_Text textS3;
    public TMP_Text textS4;

    public static bool skill1=false;
    public static bool skill2=false;
    public static bool skill3=false;
    public static bool skill4=false;
    public GameObject skill1Icon;
    public GameObject skill2Icon;
    public GameObject skill3Icon;
    public GameObject skill4Icon;

    public GameObject night2Block;
    public GameObject night3Block;
    public GameObject night4Block;
    public GameObject night5Block;
    public GameObject night6Block;
    public GameObject night7Block;
    public GameObject night8Block;
    public GameObject night9Block;

    public TMP_Text sensitivityText;

    // Start is called before the first frame update
    void Start()
    {
        levelPass = PlayerPrefs.GetInt("Level");
        Cursor.lockState = CursorLockMode.None;
        if(levelPass>=1){night2Block.SetActive(false);}
        if(levelPass>=2){night3Block.SetActive(false);}
        if(levelPass>=3){night4Block.SetActive(false);}
        if(levelPass>=4){night5Block.SetActive(false);}
        if(levelPass>=5){night6Block.SetActive(false);}
        if(levelPass>=6){night7Block.SetActive(false);}
        if(levelPass>=7){night8Block.SetActive(false);}
        if(levelPass>=8){night9Block.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){Quit();}
        if(level1>10){level1=0;}if(level1<0){level1=10;}
        if(level2>10){level2=0;}if(level2<0){level2=10;}
        if(level3>10){level3=0;}if(level3<0){level3=10;}
        if(level4>10){level4=0;}if(level4<0){level4=10;}
        text1.text=level1.ToString();
        text2.text=level2.ToString();
        text3.text=level3.ToString();
        text4.text=level4.ToString();
        if(speed1>5f){speed1=1f;}if(speed1<1f){speed1=5f;}
        if(speed2>5f){speed2=1f;}if(speed2<1f){speed2=5f;}
        if(speed3>5f){speed3=1f;}if(speed3<1f){speed3=5f;}
        if(speed4>5f){speed4=1f;}if(speed4<1f){speed4=5f;}
        textS1.text=speed1.ToString();
        textS2.text=speed2.ToString();
        textS3.text=speed3.ToString();
        textS4.text=speed4.ToString();
        if(skill1==true){skill1Icon.SetActive(true);}
        if(skill1==false){skill1Icon.SetActive(false);}
        if(skill2==true){skill2Icon.SetActive(true);}
        if(skill2==false){skill2Icon.SetActive(false);}
        if(skill3==true){skill3Icon.SetActive(true);}
        if(skill3==false){skill3Icon.SetActive(false);}
        if(skill4==true){skill4Icon.SetActive(true);}
        if(skill4==false){skill4Icon.SetActive(false);}
        Mouse();
    }
    
    public void Mouse()
    {
        sensitivityText.text=PlayerView.m.ToString();
        if(PlayerView.m>100){PlayerView.m=100;}
        if(PlayerView.m<0){PlayerView.m=0;}
    }
    public void Plus(){PlayerView.m+=1;}
    public void Mi(){PlayerView.m-=1;}

    public void Quit()
    {
        Application.Quit();
    }

    public void ToLevelMenu()
    {
        levelPanel.SetActive(true);
        // level1=5;level2=5;level3=5;level4=5;
        // speed1=1;speed2=1;speed3=1;speed4=1;
    }

    public void Night1(){SetLevel(0,2,1,false,0,1,false,0,1,false,1,1,false);}
    public void Night2(){SetLevel(1,3,1,false,3,1,false,2,1,false,3,1,false);}
    public void Night3(){SetLevel(2,3,2,false,3,2,false,3,1,false,3,2,false);}
    public void Night4(){SetLevel(3,5,1,false,4,2,false,3,2,false,3,2,true);}
    public void Night5(){SetLevel(4,4,2,false,4,1,true,4,1,false,4,2,true);}
    public void Night6(){SetLevel(5,6,1,true,4,2,true,2,3,false,4,2,true);}
    public void Night7(){SetLevel(6,2,3,true,5,2,true,3,2,true,5,2,true);}
    public void Night8(){SetLevel(7,6,2,true,5,3,true,4,2,true,5,3,true);}
    public void Night9(){SetLevel(8,6,3,true,6,3,true,6,3,true,6,3,true);}

    private void SetLevel(int z, int a, int b, bool c, int d, int e,bool f,int g, int h, bool i, int j, int k,bool l)
    {
        if(levelPass>=z)
        {
            SceneManager.LoadScene("Game");
            level1=a;level2=d;level3=g;level4=j;
            speed1=b;speed2=e;speed3=h;speed4=k;
            skill1=c;skill2=f;skill3=i;skill4=l;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToCustomModeMenu()
    {
        customPanel.SetActive(true);
    }
    public void ToSettingeMenu()
    {
        settingPanel.SetActive(true);
    }
    public void Back()
    {
        customPanel.SetActive(false);
        settingPanel.SetActive(false);
        levelPanel.SetActive(false);
    }

    public void Plus1(){level1+=1;}
    public void Plus2(){level2+=1;}
    public void Plus3(){level3+=1;}
    public void Plus4(){level4+=1;}
    public void MI1(){level1-=1;}
    public void MI2(){level2-=1;}
    public void MI3(){level3-=1;}
    public void MI4(){level4-=1;}

    public void SPlus1(){speed1+=1f;}
    public void SPlus2(){speed2+=1f;}
    public void SPlus3(){speed3+=1f;}
    public void SPlus4(){speed4+=1f;}
    public void SMI1(){speed1-=1f;}
    public void SMI2(){speed2-=1f;}
    public void SMI3(){speed3-=1f;}
    public void SMI4(){speed4-=1f;}

    public void Skill1(){
        if(skill1==false)
        {skill1=true;}
        else if(skill1==true)
        {skill1=false;}
    }
    public void Skill2(){
        if(skill2==false)
        {skill2=true;}
        else if(skill2==true)
        {skill2=false;}
    }
    public void Skill3(){
        if(skill3==false)
        {skill3=true;}
        else if(skill3==true)
        {skill3=false;}
    }
    public void Skill4(){
        if(skill4==false)
        {skill4=true;}
        else if(skill4==true)
        {skill4=false;}
    }
    
}
