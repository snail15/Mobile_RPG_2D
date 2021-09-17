using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] Text dialogText;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] Image portrait;

    [Header("Managers")]
    [SerializeField] DialogManager dialogManager;

    private GameObject scannedObject;

    public bool isScanning;
    public int dialogIdx;

    public void Scan(GameObject scannedObj)
    {
        scannedObject = scannedObj;
        ObjData objData = scannedObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        dialogPanel.SetActive(isScanning);
    }

    private void Talk(int id, bool isNPC)
    {
        string dialog = dialogManager.GetDialog(id, dialogIdx);
        
        if (dialog == null)
        {
            isScanning = false;
            dialogIdx = 0;
            return;
        }

        if (isNPC)
        {
            string[] splitTxt = dialog.Split(':');
            dialogText.text = splitTxt[0];
            portrait.sprite = dialogManager.GetPortait(id, int.Parse(splitTxt[1]));
            portrait.color = new Color(1, 1, 1, 1);
        }
        else
        {
            dialogText.text = dialog;
            portrait.color = new Color(1, 1, 1, 0);
        }
        isScanning = true;
        dialogIdx += 1;
    }
}
