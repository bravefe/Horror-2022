using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost4 : MonoBehaviour
{
    private int walkLoop;
    public static int level = 10;
    public bool skill = false;
    public float timeTillMove = 3f;
    public static float timeLoop = 3f;
    private int move;
    private int moveTimes = 0;
    private int maxMove = 10;

    private float xPosition = -20f;
    private float zPosition = -10f;

    // Start is called before the first frame update
    void Start()
    {
        level=Menu.level4;
        float s=Menu.speed4-1f;
        timeTillMove=2f-s;
        timeLoop=7.7f-s;
        skill=Menu.skill4;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLoop<2.1){timeLoop=2.1f;}
        if(PlayerView.gameStop == false)
        {timeTillMove -= Time.deltaTime;}
        if(Door.doorCount>=1&&skill==true){timeTillMove=0;Door.doorCount-=1;}
        if (timeTillMove <= 0)
        {
            timeTillMove = timeLoop;
            move = Random.Range(1, 11);
            if (move <= level)
            {
                if (moveTimes == 100) {}
                else if (moveTimes <= 1) 
                {
                    xPosition += 10;
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                    moveTimes += 1;
                }
                else if (moveTimes >= 2 && moveTimes <= 9)
                {
                    walkLoop = Random.Range(0, 4);
                    if (walkLoop == 0)
                    {
                        if (zPosition < 0)
                        {
                            zPosition += 10;
                            transform.position = new Vector3 (xPosition, 0, zPosition);
                            moveTimes += 1;
                        }
                    }
                    if (walkLoop == 2)
                    {
                        if (zPosition > -20)
                        {
                            zPosition -= 10;
                            transform.position = new Vector3 (xPosition, 0, zPosition);
                            moveTimes += 1;
                        }    
                    }
                    if (walkLoop == 1)
                    {
                        if (xPosition < 20)
                        {
                            xPosition += 10;
                            transform.position = new Vector3 (xPosition, 0, zPosition);
                            moveTimes += 1;
                        }
                    }
                    if (walkLoop == 3)
                    {
                        if (xPosition > 0)
                        {
                            xPosition -= 10;
                            transform.position = new Vector3 (xPosition, 0, zPosition);
                            moveTimes += 1;
                        }    
                    }
                }
                if (moveTimes == maxMove)
                {
                    moveTimes = 1;
                    xPosition = -10f;
                    zPosition = -10f;        
                    transform.position = new Vector3 (xPosition, 0, zPosition);    
                }
            }
        }   
    }
}
