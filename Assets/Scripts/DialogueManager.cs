using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public Image portraitImg;
    public Text dialogText;
    public Text nameTag;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public static DialogueManager instance;

    public DialogueDataManager dialogueDataManager;

    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    // Start is called before the first frame update
    //player scan object ㄱㅏㅈㅕㅇㅗㅏㅅㅓ, ㅌㅔㄱㅅㅡㅌㅡㄹㅗ ㅃㅜㄹㅣㄴㄷㅏ.

    // Update is called once per frame
    public void LoadDialogue(GameObject scanObj)
    {
            scanObject = scanObj;
            nameTag.text = scanObj.name;
            ObjectData objectData = scanObject.GetComponent<ObjectData>();
            Talk(objectData.id, objectData.isNpc);

            DialogueCanvas.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string dialogueData = dialogueDataManager.GetDialogue(id, talkIndex);

        if (dialogueData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            string[] dialogueDatas = dialogueData.Split(':');
            portraitImg.sprite = dialogueDataManager.GetPortrait(id, int.Parse(dialogueDatas[1]));
            dialogText.text = dialogueDatas[0];

            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        { 
            dialogText.text = dialogueData;


            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
