using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] TypeEffect typeEffect;
    [SerializeField] Animator dialogPanel;
    [SerializeField] Image portrait;
    [SerializeField] Sprite prevPortrait;
    [SerializeField] Animator portraitAnim;
    [SerializeField] GameObject menuSet;
    [SerializeField] Text questText;

    [Header("Managers")]
    [SerializeField] DialogManager dialogManager;
    [SerializeField] QuestManager questManager;

    [Header("For Save")]
    [SerializeField] GameObject player;

    private GameObject scannedObject;
    

    public bool isScanning;
    public int dialogIdx;

    private void Start()
    {

        LoadGame();
        questText.text = questManager.CheckQuest();
    }

    private void Update()
    {
       
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
            
    }

    public void Scan(GameObject scannedObj)
    {
        scannedObject = scannedObj;
        ObjData objData = scannedObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        dialogPanel.SetBool("isShowing", isScanning);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questOrderIdx);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questOrderIdx = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, -5);
        questManager.questId = questId;
        questManager.questOrderIdx = questOrderIdx;
        questManager.ControlObject();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Talk(int id, bool isNPC)
    {
        int questTalkIndex = 0;
        string dialog = string.Empty;

        if (typeEffect.isAnimating)
        {
            typeEffect.SetMsg(string.Empty);
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            dialog = dialogManager.GetDialog(id + questTalkIndex, dialogIdx);
        }
        
        
        if (dialog == null)
        {
            isScanning = false;
            dialogIdx = 0;
            questText.text = questManager.CheckQuest(id);
            return;
        }

        if (isNPC)
        {
            string[] splitTxt = dialog.Split(':');
            typeEffect.SetMsg(splitTxt[0]);
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
            typeEffect.SetMsg(dialog);
            portrait.color = new Color(1, 1, 1, 0);
        }
        isScanning = true;
        dialogIdx += 1;
    }
}
