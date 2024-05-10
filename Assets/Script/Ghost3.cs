using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost3 : MonoBehaviour
{
    private int walkLoop;
    public static int level = 10;
    public bool skill = false;
    public float timeTillMove = 3f;
    public static float timeLoop = 3f;
    private int move;
    public int moveTimes = 0;

    private float xPosition = 10f;
    private float zPosition = -40f;

    public Door door0;
    public Door door1;
    public Door door3;
    public Door door5;
    public Door door6;
    public Door door8;
    public Door door10;
    public Door door11;

    public Room room0;
    public Room room2;
    public Room room3;
    public Room room5;
    public Room room6;
    public Room room8;


    // Start is called before the first frame update
    void Start()
    {
        level=Menu.level3;
        float s=Menu.speed3-1f;
        timeTillMove=4f-s;
        timeLoop=6.9f-s;
        skill=Menu.skill3;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLoop<2.5){timeLoop=2.5f;}
        if(PlayerView.gameStop == false)
        {timeTillMove -= Time.deltaTime;}
        if(PlayerMove.playerMoveCount>=2&&skill==true){timeTillMove=0;PlayerMove.playerMoveCount-=2;}
        if (timeTillMove <= 0)
        {
            timeTillMove = timeLoop;
            move = Random.Range(1, 11);
            if (move <= level)
            {
                if (moveTimes == 100) {}
                else if (moveTimes <= 3)
                {
                    if(moveTimes<=1)
                    {
                        zPosition+=10;
                        moveTimes += 1;
                        transform.position = new Vector3 (xPosition, 0, zPosition);
                    }
                    else if (moveTimes==2)
                    {CheckRoom(room6,-10f,-10f,door10);
                    CheckRoom(room8,10f,-10f,door11);
                    Move(10,door8);}
                    else if (moveTimes==3)
                    {CheckRoom(room3,-10f,-10f,door5);
                    CheckRoom(room5,10f,-10f,door6);
                    Move(10,door3);}
                }
                else if (moveTimes >= 4 )
                {
                    if (moveTimes == 4){
                    CheckRoom(room0,-10f,10f,door0);
                    CheckRoom(room2,10f,10f,door1);
                    Move(-10,door3);}
                    else if (moveTimes == 5){
                    CheckRoom(room3,-10f,10f,door5);
                    CheckRoom(room5,10f,10f,door6);
                    Move(-10,door8);}
                    else if (moveTimes == 6){
                    CheckRoom(room6,-10f,10f,door10);
                    CheckRoom(room8,10f,10f,door11);
                    zPosition+=-10;
                    moveTimes += 1;
                    transform.position = new Vector3 (xPosition, 0, zPosition);}
                    else if (moveTimes == 7){
                    zPosition+=-10;
                    moveTimes += 1;
                    transform.position = new Vector3 (xPosition, 0, zPosition);}
                    else if (moveTimes == 8) {moveTimes = 0;
                    xPosition=10;
                    zPosition=-40;
                    transform.position = new Vector3 (xPosition, 0, zPosition);}
                }
            }
        }
    }

    private void CheckRoom(Room r,float a, float b,Door d)
    {
        if(r.playerInRoom == true && d.doorClosed == false)
        {
            xPosition+=a;
            zPosition+=b;
            transform.position = new Vector3 (xPosition, 0, zPosition);
        }
    }

    private void Move(float b,Door r)
    {
        if(r.doorClosed==false)
        {
            zPosition+=b;
            moveTimes += 1;
        }
        if(r.doorClosed==true)
        {timeTillMove=2;}
        transform.position = new Vector3 (xPosition, 0, zPosition);      
        
    }

}
