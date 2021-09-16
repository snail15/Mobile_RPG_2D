using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    Dictionary<int, string[]> dialogData;

    private void Awake()
    {
        dialogData = new Dictionary<int, string[]>();
        GenerateDialogData();
    }

    public string GetDialog(int objId, int dialogIdx)
    {
        return dialogData[objId][dialogIdx];
    }

    private void GenerateDialogData()
    {
        dialogData.Add(1000, new string[] { "안녕?", "이 곳에 처음 왔구나?" });
        dialogData.Add(100, new string[] { "평범한 나무상자다.." });
        dialogData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다" });
    }
}
