using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public bool playerInRoom = false;
    public bool ghost1InRoom = false;
    public bool ghost2InRoom = false;
    public bool ghost3InRoom = false;
    public bool ghost4InRoom = false;

    public GameObject deadPanel1;
    public GameObject deadPanel2;
    public GameObject deadPanel3;
    public GameObject deadPanel4;

    public Seal seal1; 
    public Seal seal2; 
    public Seal seal3; 
    public Seal seal4; 
    
    // public enum Mark {None,North,East,South,West};
    // public Mark mark;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckLose();
    }
    
    private void CheckLose()
    {
        if(playerInRoom == true&&ghost1InRoom ==true&&seal1.wasSeal == false)
        {deadPanel1.SetActive(true);StartCoroutine(Wait(2f));}
        if(playerInRoom == true&&ghost2InRoom ==true&&seal2.wasSeal == false)
        {deadPanel2.SetActive(true);StartCoroutine(Wait(2f));}
        if(playerInRoom == true&&ghost3InRoom ==true&&seal3.wasSeal == false)
        {deadPanel3.SetActive(true);StartCoroutine(Wait(2f));}
        if(playerInRoom == true&&ghost4InRoom ==true&&seal4.wasSeal == false)
        {deadPanel4.SetActive(true);StartCoroutine(Wait(2f));}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){playerInRoom = true;}
        if (other.tag == "Enemy1") {ghost1InRoom = true;}
        if (other.tag == "Enemy2") {ghost2InRoom = true;}   
        if (other.tag == "Enemy3") {ghost3InRoom = true;} 
        if (other.tag == "Enemy4") {ghost4InRoom = true;}     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){playerInRoom = false;}       
        if (other.tag == "Enemy1") {ghost1InRoom = false;}
        if (other.tag == "Enemy2") {ghost2InRoom = false;}   
        if (other.tag == "Enemy3") {ghost3InRoom = false;}   
        if (other.tag == "Enemy4") {ghost4InRoom = false;}   
    }
    public IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Menu"); 
    }
}
