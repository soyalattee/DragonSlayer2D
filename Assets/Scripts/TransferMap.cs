using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransferMap : MonoBehaviour
{
    public string transfersceneName;
    public string currentMap;
    private MovingObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
    }

    public void SetChangeSceneName(string transfersceneName)
    {
        transfersceneName = this.transfersceneName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player"){
            thePlayer.currentMapName = transfersceneName;
            SceneManager.LoadScene(transfersceneName);
        }
    }
}
