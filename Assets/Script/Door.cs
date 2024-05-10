using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public GameObject mimimapDoor;
    public bool doorClosed = false;
    public static int doorCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorClosed == false){door.SetActive(false);
        mimimapDoor.SetActive(false); }
        else if(doorClosed == true){door.SetActive(true);
        mimimapDoor.SetActive(true);}
    }

    void OnMouseDown()
    {
        if(PlayerMove.tutorial==true&&PlayerMove.learn==3){PlayerMove.learn+=1;}
        if (doorClosed == false&&PlayerView.gameStop == false)
        {doorClosed = true;FindObjectOfType<AudioManager>().Play("DoorClose");doorCount+=1;}
        else if (doorClosed == true&&PlayerView.gameStop == false)
        {doorClosed = false;FindObjectOfType<AudioManager>().Play("DoorOpen");}
    }
}
