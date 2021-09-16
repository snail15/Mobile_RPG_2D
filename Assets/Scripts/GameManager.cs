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

    [Header("Managers")]
    [SerializeField] DialogManager dialogManager;

    private GameObject scannedObject;

    public bool isScanning;
    public int dialogIdx;

    public void Scan(GameObject scannedObj)
    {
        if (isScanning)
        {
            isScanning = false;
        }
        else
        {
            isScanning = true;
            scannedObject = scannedObj;
            ObjData objData = scannedObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNPC);
        }

        dialogPanel.SetActive(isScanning);


    }

    private void Talk(int id, bool isNPC)
    {
        string dialog = dialogManager.GetDialog(id, dialogIdx);
        if (isNPC)
        {
            dialogText.text = dialog;
        }
        else
        {
            dialogText.text = dialog;
        }
    }
}
