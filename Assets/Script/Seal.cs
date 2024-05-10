using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seal : MonoBehaviour
{
    public GameObject ghost;
    public float sealTime = 10f;
    private float sealTimeOrigin;
    public bool sealing = false;
    public bool wasSeal = false;
    public static int sealCount = 0;
    public static int sealedCount = 0;

    public Image SealBar;
    public GameObject sealBar;

    public GameObject seal;

    // Start is called before the first frame update
    void Start()
    {
        sealTimeOrigin=sealTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (sealing == true&&PlayerView.gameStop == false) 
        {
            sealBar.SetActive(true);
            sealTime -= Time.deltaTime;
            SealBar.fillAmount=sealTime/sealTimeOrigin;
            
        }
        if (sealTime <= 0) 
        {
            if(PlayerMove.tutorial==true&&PlayerMove.learn==5){PlayerMove.learn+=1;}
            Destroy(ghost);Destroy(gameObject); 
            sealing = false; wasSeal = true;sealedCount+=1;
            Ghost1.level+=1;
            Ghost2.level+=1;
            Ghost3.level+=1;
            Ghost4.level+=1;
            Ghost1.timeLoop-=1;
            Ghost2.timeLoop-=1;
            Ghost3.timeLoop-=1;
            Ghost4.timeLoop-=1;
            FindObjectOfType<AudioManager>().Play("Seal");
            FindObjectOfType<AudioManager>().Pause("Sealing");
        }
        // if (wasSeal == true){sealBar.SetActive(true);}
    }

    void OnMouseDown()
    {
        if (sealing == false && PlayerView.gameStop == false) 
        {
            if(PlayerMove.tutorial==true&&PlayerMove.learn==4){PlayerMove.learn+=1;}
            sealCount+=1;
            sealing = true;
            FindObjectOfType<AudioManager>().Pause("Sealing");
        }
        else if(sealing ==true&& PlayerView.gameStop == false)
        {
            sealing = false;
            sealBar.SetActive(false);
            FindObjectOfType<AudioManager>().Pause("Sealing");
        }
    }
}
