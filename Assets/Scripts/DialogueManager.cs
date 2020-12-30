using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public Text dialogText;
    public Text nameTag;
    public GameObject scanObject;
    public bool isAction;
    // Start is called before the first frame update
    //player scan object ㄱㅏㅈㅕㅇㅗㅏㅅㅓ, ㅌㅔㄱㅅㅡㅌㅡㄹㅗ ㅃㅜㄹㅣㄴㄷㅏ.

    // Update is called once per frame
    public void LoadDialogue(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            nameTag.text = scanObj.name;
            dialogText.text = " 내 이름은 " + scanObject.name + "야";
        }
            DialogueCanvas.SetActive(isAction);
    }
}
