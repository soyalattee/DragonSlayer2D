using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransferMap : MonoBehaviour
{
    public string transfersceneName;
    public string currentMap;
    private MovingObject thePlayer;
    private FadeInOut fader;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MovingObject>();
        fader = FindObjectOfType<FadeInOut>();
    }

    public void SetChangeSceneName(string transfersceneName)
    {
        transfersceneName = this.transfersceneName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player"){
            thePlayer.currentMapName = transfersceneName;
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        fader.Fade(()=>{
            SceneManager.LoadScene(transfersceneName);
        });
        
        yield return null;
    }
}
