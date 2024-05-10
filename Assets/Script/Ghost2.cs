using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2 : MonoBehaviour
{
    public int walkLoop;
    public static int level = 10;
    public bool skill = false;
    public float timeTillMove = 3f;
    public static float timeLoop = 3f;
    private int move;
    public int moveTimes = 0;

    // public bool waiting3 = false;
    // public bool waiting5 = false;
    // public bool waiting6 = false;
    // public bool waiting8 = false;

    private float xPosition = 40f;
    private float zPosition = -10f;

    public Door door3;
    public Door door5;
    public Door door6;
    public Door door8;

    // Start is called before the first frame update
    void Start()
    {
        walkLoop = Random.Range(0, 2);
        level=Menu.level2;
        float s=Menu.speed2-1f;
        timeLoop=8.3f-s*1.5f;
        skill=Menu.skill2;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLoop<2.3){timeLoop=2.3f;}
        // if(door3.doorClosed==false){waiting3=false;}
        // if(door5.doorClosed==false){waiting5=false;}
        // if(door6.doorClosed==false){waiting6=false;}
        // if(door8.doorClosed==false){waiting8=false;}
        if(PlayerView.gameStop == false)
        {timeTillMove -= Time.deltaTime;}
        if(PlayerMove.flashLightCount>=1&&skill==true){timeTillMove=0;PlayerMove.flashLightCount-=1;}
        if (timeTillMove <= 0 //&& waiting3 == false && waiting5 == false && waiting6 == false && waiting6 = false
        )
        {
            timeTillMove = timeLoop;
            move = Random.Range(1, 11);
            if (move <= level)
            {
                if (moveTimes == 100) {}
                else if (moveTimes == 0 || moveTimes == 1) 
                {                 
                    xPosition -= 10;
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                    moveTimes += 1;
                }
                else if(moveTimes== 2)
                {
                        if(door6.doorClosed==false)
                        {xPosition-=10;moveTimes+=1;}
                        if(door6.doorClosed==true)
                        {timeTillMove=0;}
                        transform.position = new Vector3 (xPosition, 0, zPosition);
                }
                else if(moveTimes==5)
                {
                        if(door5.doorClosed==false)
                        {xPosition -= 10;moveTimes += 1;}
                        if(door5.doorClosed==true)
                        {timeTillMove=0;}
                        transform.position = new Vector3 (xPosition, 0, zPosition);
                }
                else if (moveTimes == 3)
                {
                    if (walkLoop == 0){
                        if(door8.doorClosed==false)
                        {zPosition -= 10;moveTimes += 1;}
                        if(door8.doorClosed==true)
                        {timeTillMove=0;}}
                    if (walkLoop == 1){
                        if(door3.doorClosed==false)
                        {zPosition += 10;moveTimes += 1;}
                        if(door3.doorClosed==true)
                        {timeTillMove=0;}}
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                }
                else if (moveTimes == 4 || moveTimes == 6 || moveTimes == 8)
                {
                    if(moveTimes==6){
                        if(door5.doorClosed==false)
                        {xPosition=10;zPosition=-10;moveTimes+=1;}
                        if(door5.doorClosed==true)
                        {timeTillMove=0;}}
                    if(moveTimes==4){
                        if (walkLoop == 0){
                            if(door8.doorClosed==false)
                            {{xPosition=10;zPosition=-10;moveTimes += 1;}
                            if(door8.doorClosed==true)
                            {timeTillMove=0;}}}
                        if (walkLoop == 1){
                            if(door3.doorClosed==false)
                            {{xPosition=10;zPosition=-10;moveTimes += 1;}
                            if(door3.doorClosed==true)
                            {timeTillMove=0;}}}}
                    if(moveTimes==8){
                        if (walkLoop == 1){
                            if(door8.doorClosed==false)
                            {{xPosition=10;zPosition=-10;moveTimes += 1;}
                            if(door8.doorClosed==true)
                            {timeTillMove=0;}}}
                        if (walkLoop == 0){
                            if(door3.doorClosed==false)
                            {{xPosition=10;zPosition=-10;moveTimes += 1;}
                            if(door3.doorClosed==true)
                            {timeTillMove=0;}}}}
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                }
                else if (moveTimes == 7)
                {
                    if (walkLoop == 1){
                        if(door8.doorClosed==false)
                        {zPosition -= 10;moveTimes += 1;}
                        if(door8.doorClosed==true)
                        {timeTillMove=0;}}
                    if (walkLoop == 0){
                        if(door3.doorClosed==false)
                        {zPosition += 10;moveTimes += 1;}
                        if(door3.doorClosed==true)
                        {timeTillMove=0;}}
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                }
                else if (moveTimes == 9)
                {
                        if(door6.doorClosed==false)
                        {xPosition+=10;moveTimes+=1;}
                        if(door6.doorClosed==true)
                        {timeTillMove=0;}
                        transform.position = new Vector3 (xPosition, 0, zPosition);        
                }
                else if (moveTimes >= 10 && moveTimes <= 12)
                {
                    xPosition += 10;
                    transform.position = new Vector3 (xPosition, 0, zPosition);
                    moveTimes += 1;
                    if (moveTimes == 12)
                    {
                        moveTimes = 0;            
                        walkLoop = Random.Range(0, 2);
                    }
                }
            }
        }
    }
}
