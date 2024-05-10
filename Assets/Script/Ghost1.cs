using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : MonoBehaviour
{
    public int walkLoop;
    public static int level;
    public bool skill = false;
    public float timeTillMove;
    public static float timeLoop;
    private int move;
    public int moveTimes = 0;
    private bool moving = false;

    private float xPosition = 10f;
    private float zPosition = 20f;


    public Door door0;
    public Door door1;
    public Door door2;
    public Door door4;
    public Door door7;
    public Door door9;
    public Door door10;
    public Door door11;

     // Start is called before the first frame update
    void Start()
    {
        walkLoop = Random.Range(0, 2);
        level=Menu.level1;
        float s=Menu.speed1-1f;
        timeTillMove=3f-s;
        timeLoop=7.1f-s;
        skill=Menu.skill1;
        // StartCoroutine(Wait(timeTillMove));
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTimes==10){moveTimes=2;}
        if(timeLoop<2.9){timeLoop=2.9f;}
        if(PlayerView.gameStop == false)
        {timeTillMove -= Time.deltaTime;}
        if(Seal.sealCount>=1&&skill==true){timeTillMove=0;Seal.sealCount-=1;}
        if (timeTillMove <= 0)
        {
            timeTillMove = timeLoop;
            move = Random.Range(1, 11);
            if (move <= level)
            {
                if (moveTimes == 100) {}
                else if (moveTimes < 2) 
                {
                    zPosition -= 10;
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                    moveTimes += 1;
                }
                else if (moveTimes == 2)
                {
                    if(walkLoop==0){Move(10f,0,door1);}
                    else if(walkLoop==1){Move(-10f,0,door0);}
                }
                else if (moveTimes == 3)
                {
                    if(walkLoop==0){Move(0,-10f,door4);}
                    else if(walkLoop==1){Move(0,-10f,door2);}
                }
                else if (moveTimes == 4)
                {
                    if(walkLoop==0){Move(0,-10f,door9);}
                    else if(walkLoop==1){Move(0,-10f,door7);}
                }
                else if (moveTimes == 5 )
                {
                    if(walkLoop==0){Move(-10f,0,door11);}
                    else if(walkLoop==1){Move(10f,0,door10);}
                }
                else if (moveTimes ==6)
                {
                    if(walkLoop==0){Move(-10f,0,door10);}
                    else if(walkLoop==1){Move(10f,0,door11);}
                }
                else if (moveTimes==7)
                {
                    if(walkLoop==0){Move(0,10f,door7);}
                    else if(walkLoop==1){Move(0,10f,door9);}
                }
                else if (moveTimes==8)
                {
                    if(walkLoop==0){Move(0,10f,door2);}
                    else if(walkLoop==1){Move(0,10f,door4);}
                }
                else if (moveTimes == 9)
                {                    
                    if(walkLoop==0){Move(10f,0,door0);}
                    else if(walkLoop==1){Move(-10f,0,door1);}

                }
            }
        }
    }
    private void Move(float a, float b,Door d)
    {
        if(d.doorClosed==false)
        {
            moving=true;
            xPosition+=a;
            zPosition+=b;
            transform.position = new Vector3 (xPosition, 0, zPosition);
            moveTimes+=1;
        }
        if(d.doorClosed==true&&moving==true)
        {
            moving=false;
            moveTimes-=10;moveTimes*=-1;moveTimes+=2;timeTillMove=0;
            if(walkLoop==0){walkLoop=1;}
            else if(walkLoop==1){walkLoop=0;}
        }
    }
}