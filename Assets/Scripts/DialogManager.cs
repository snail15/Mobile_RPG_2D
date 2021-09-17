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
        dialogData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        dialogData.Add(2000, new string[] { "����..:1", "�� ȣ���� ���� �Ƹ�����?:0", "��� �� ȣ������ ����� �ִٰ���..:1" });
        dialogData.Add(100, new string[] { "����� �������ڴ�.." });
        dialogData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�" });

        dialogData.Add(10 + 1000, new string[] { "� ��:0", "�� �������� ������ �־�:1", "ȣ������ �絵�� �˷��ٲ���..:2" });
        dialogData.Add(11 + 2000, new string[] { "����..:1", "�� ȣ���� ������ ������ �°ž�?:0", "�׷� �� �� �ϳ� ���ָ� �����ٵ�..:1", "�� �� ��ó�� ���� �� �ֿ������� ��..:1" });

        dialogData.Add(20 + 1000, new string[] { "�絵�� ��?:1", "���� �긮�� �ٴϸ� ������!:3", "���߿� �絵���� �Ѹ��� �ؾ߰ھ�..:3" });
        dialogData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��..:1"});
        dialogData.Add(20 + 5000, new string[] { "��ó���� ���� ã�Ҵ�!! ���� �絵���� ������" });

        dialogData.Add(21 + 2000, new string[] { "��, ã���༭ ����!:2" });

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
