using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] Sprite[] portaits;

    Dictionary<int, string[]> dialogData;
    Dictionary<int, Sprite> portraitData;

    private void Awake()
    {
        dialogData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>(); ;
        GenerateDialogData();
    }

    public string GetDialog(int objId, int dialogIdx)
    {
        if (dialogIdx == dialogData[objId].Length)
            return null;

        return dialogData[objId][dialogIdx];
    }

    public Sprite GetPortait(int objId, int portraitIdx)
    {
        return portraitData[objId + portraitIdx];
    }

    private void GenerateDialogData()
    {
        dialogData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        dialogData.Add(2000, new string[] { "여어..:1", "이 호수는 정말 아름답지?:0", "사실 이 호수에는 비밀이 있다고해..:1" });
        dialogData.Add(100, new string[] { "평범한 나무상자다.." });
        dialogData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다" });

        portraitData.Add(1000 + 0, portaits[0]);
        portraitData.Add(1000 + 1, portaits[1]);
        portraitData.Add(1000 + 2, portaits[2]);
        portraitData.Add(1000 + 3, portaits[3]);
        portraitData.Add(2000 + 0, portaits[4]);
        portraitData.Add(2000 + 1, portaits[5]);
        portraitData.Add(2000 + 2, portaits[6]);
        portraitData.Add(2000 + 3, portaits[7]);

    }
}
