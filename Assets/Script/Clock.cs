using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clock;
    public float time;
    private bool pass23=false;
    private bool pass0=false;
    private bool pass1=false;
    // private bool pass2=false;
    // private bool pass2330=false;
    // private bool pass2230=false;

    // Start is called before the first frame update
    void Start()
    {
        time=1320f;
    }

    // Update is called once per frame
    void Update()
    {
        int h=Mathf.FloorToInt(time/60f);
        int m=Mathf.FloorToInt(time-h*60f);
        if(PlayerView.gameStop==false)
        {
            time+=Time.deltaTime*2;
            if(time>=1440){time=0;}

            clock.text=string.Format("{0:00}:{1:00}",h,m);
        }
        if(pass23==false&&h==23)
        {
            Ghost1.level+=1;
            Ghost2.level+=1;
            Ghost3.level+=1;
            Ghost4.level+=1;
            pass23=true;
        }
        if(pass0==false&&h==0)
        {
            Ghost1.level+=1;
            Ghost2.level+=1;
            Ghost3.level+=1;
            Ghost4.level+=1;
            pass0=true;
        }
        if(pass1==false&&h==1)
        {
            Ghost1.level+=1;
            Ghost2.level+=1;
            Ghost3.level+=1;
            Ghost4.level+=1;
            pass1=true;
        }
        // if(pass2330==false&&h==23&&m>=30)
        // {
        //     Ghost1.level+=1;
        //     Ghost2.level+=1;
        //     Ghost3.level+=1;
        //     Ghost4.level+=1;
        //     pass2330=true;
        // }
    }
}
