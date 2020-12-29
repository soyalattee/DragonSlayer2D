using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    public static FadeInOut instance;


    void Start(){
        if(instance == null){
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
    public void Fade(System.Action nextEvent =null){
        StartCoroutine(FadeFlow(nextEvent));
    }

    IEnumerator FadeFlow(System.Action nextEvent = null)
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        time=0f;
        while(alpha.a < 1f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }

        if(nextEvent != null) nextEvent();
        time = 0f;

        yield return new WaitForSeconds(1f);
        while(alpha.a > 0f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
