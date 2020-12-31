using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDataManager : MonoBehaviour
{
    Dictionary<int, string[]> dialogueData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        dialogueData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    /**
     추후 data file 분리해서 가져오는 방식으로 변경하자! 
     */
    void GenerateData()
    {
        //Adward
        dialogueData.Add(1000, new string[] { "이게 얼마만이야! \n 정말 보고싶었어......:2", "무엇을 도와줄까? 뭐든 말만해!:1"});
        //표지판
        dialogueData.Add(100, new string[] { " 표지판이다. \n \"슬라임 서식지\" 라고 적혀있다.  " });
        //마을주민1
        dialogueData.Add(200, new string[] { "그 소문 들었어?", "봉인된 용이 깨어난거 같대... \n 요즘들어 몬스터들이 늘어난 것도 그 영향이라나!!" });

        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

    }

    public string GetDialogue(int id, int talkIndex)
    {
        if (talkIndex == dialogueData[id].Length)
            return null;
        else
            return dialogueData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
