using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public float rotationAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerView.playerFacing == 0){rotationAngle = 0;}
        if (PlayerView.playerFacing == 1){rotationAngle = 90;}
        if (PlayerView.playerFacing == 2){rotationAngle = 180;}
        if (PlayerView.playerFacing == 3){rotationAngle = -90;}
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,0,rotationAngle), 300*Time.deltaTime);
    }
}
