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
        if (!dialogData.ContainsKey(objId))
        {
            if (!dialogData.ContainsKey(objId - objId % 10))
            {
                return GetDialog(objId - objId % 100, dialogIdx); //Get very first dialog
            }
            else
            {
                return GetDialog(objId - objId % 10, dialogIdx); //Get quest first dialog
            }
        }
    
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

        dialogData.Add(10 + 1000, new string[] { "어서 와:0", "이 마을에는 전설이 있어:1", "호숫가에 루도가 알려줄꺼야..:2" });
        dialogData.Add(11 + 2000, new string[] { "여어..:1", "이 호수의 전설을 들으러 온거야?:0", "그럼 일 좀 하나 해주면 좋을텐데..:1", "내 집 근처에 돌을 좀 주워줬으면 해..:1" });

        dialogData.Add(20 + 1000, new string[] { "루도의 돌?:1", "돌을 흘리고 다니면 못쓰지!:3", "나중에 루도에게 한마디 해야겠어..:3" });
        dialogData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘..:1"});
        dialogData.Add(20 + 5000, new string[] { "근처에서 돌을 찾았다!! 이제 루도에게 가보자" });

        dialogData.Add(21 + 2000, new string[] { "엇, 찾아줘서 고마워!:2" });

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
