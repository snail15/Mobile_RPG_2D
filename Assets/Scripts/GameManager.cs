using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] Text dialogText;
    [SerializeField] Animator dialogPanel;
    [SerializeField] Image portrait;
    [SerializeField] Sprite prevPortrait;
    [SerializeField] Animator portraitAnim;

    [Header("Managers")]
    [SerializeField] DialogManager dialogManager;
    [SerializeField] QuestManager questManager;

    private GameObject scannedObject;
    

    public bool isScanning;
    public int dialogIdx;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Scan(GameObject scannedObj)
    {
        scannedObject = scannedObj;
        ObjData objData = scannedObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        dialogPanel.SetBool("isShowing", isScanning);
    }

    private void Talk(int id, bool isNPC)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string dialog = dialogManager.GetDialog(id + questTalkIndex, dialogIdx);
        
        if (dialog == null)
        {
            isScanning = false;
            dialogIdx = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNPC)
        {
            string[] splitTxt = dialog.Split(':');
            dialogText.text = splitTxt[0];
            portrait.sprite = dialogManager.GetPortait(id, int.Parse(splitTxt[1]));
            portrait.color = new Color(1, 1, 1, 1);
            if (prevPortrait != portrait.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portrait.sprite;
            }
                
            
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
