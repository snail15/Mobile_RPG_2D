using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questOrderIdx;

    [SerializeField] GameObject[] questObject;

    private Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    public int GetQuestTalkIndex(int npcId)
    {
        return questId + questOrderIdx;
    }

    public string CheckQuest(int npcId)
    {

        if (npcId == questList[questId].npcId[questOrderIdx])
            questOrderIdx += 1;
        
        ControlObject();

        if (questOrderIdx == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    private void NextQuest()
    {
        questId += 10;
        questOrderIdx = 0;
    }

    private void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questOrderIdx == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questOrderIdx == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }

    private void GenerateData()
    {
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] { 1000, 2000}));
        questList.Add(20, new QuestData("�絵�� ���� ã���ֱ�", new int[] { 5000, 2000}));
        questList.Add(30, new QuestData("�� Ŭ����!", new int[] { 0}));
    }
}
