using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] int charPerSecond;
    [SerializeField] string targetMessage;
    [SerializeField] GameObject endCursor;
    
    private AudioSource audio;
    private Text msgText;
    private int idx;
    
    public bool isAnimating;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audio = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnimating)
        {
            msgText.text = targetMessage;
            CancelInvoke("EffectProcessing");
            EffectEnd();
        }
        else
        {
            targetMessage = msg;
            EffectStart();
        }
        
    }

    private void EffectStart()
    {
        msgText.text = string.Empty;
        idx = 0;

        endCursor.SetActive(false);

        float interval = 1.0f / charPerSecond;
        Invoke("EffectProcessing", interval);
    }

    private void EffectProcessing()
    {

        if (msgText.text.Equals(targetMessage))
        {
            EffectEnd();
            return;
        }


        if (targetMessage[idx] != ' ' || targetMessage[idx] != '.')
            audio.Play();

        msgText.text += targetMessage[idx];
        idx += 1;

        float interval = 1.0f / charPerSecond;
        isAnimating = true;
        Invoke("EffectProcessing", interval);
    }

    private void EffectEnd()
    {
        isAnimating = false;
        endCursor.SetActive(true);
    }
}
