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
        dialogData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        dialogData.Add(2000, new string[] { "����..:1", "�� ȣ���� ���� �Ƹ�����?:0", "��� �� ȣ������ ����� �ִٰ���..:1" });
        dialogData.Add(100, new string[] { "����� �������ڴ�.." });
        dialogData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�" });

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
