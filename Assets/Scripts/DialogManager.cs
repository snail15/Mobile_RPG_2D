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
        dialogData.Add(1000, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" });
        dialogData.Add(100, new string[] { "����� �������ڴ�.." });
        dialogData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�" });
    }
}
