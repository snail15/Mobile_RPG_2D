using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] Text dialogText;
    [SerializeField] GameObject dialogPanel;

    private GameObject scannedObject;

    public bool isScanning;


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
            dialogText.text = $"This is: {scannedObject.name}";
        }

        dialogPanel.SetActive(isScanning);


    }

}
