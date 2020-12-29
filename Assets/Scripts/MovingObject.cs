using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public string currentMapName;
    public static MovingObject instance;

    void Start()
    {
        if(instance == null){
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
}
