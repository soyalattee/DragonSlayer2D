using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private MovingObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();

        if(startPoint == thePlayer.currentMapName){
            thePlayer.transform.position = this.transform.position;
        }
    }

}
