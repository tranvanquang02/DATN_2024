using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image portrait;
    DialogueContainer currentDialogue;
    int currentTextLine;

    [Range(0f, 1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PushText();
        }
        TypeOutText();
    }

    private void TypeOutText()
    {
        if(visibleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Math.Clamp(visibleTextPercent, 0f, 1f);
        UpdateText();
    }
    void UpdateText()
    {
        int lettercount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, lettercount);
    }
    private void PushText()
    {
       if(visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }

        if(currentTextLine >= currentDialogue.line.Count)
        {
            Conclude();
        }
        else
        {
            CycleLine();
        }
    }
    void CycleLine()
    {
        lineToShow = currentDialogue.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        targetText.text = "";

        currentTextLine += 1;
    }

    public void Initialize(DialogueContainer dialogueContainer)
    {
        Show(true);
        currentDialogue = dialogueContainer;
        currentTextLine = 0;
        CycleLine();
        UpdatePortrait();
    }

    private void UpdatePortrait()
    {
        portrait.sprite = currentDialogue.actor.portrait;
        nameText.text = currentDialogue.actor.name;
    }

    private void Show(bool showdialogpanel)
    {
        gameObject.SetActive(showdialogpanel);
    }

    private void Conclude()
    {
        Debug.Log("dialog has end");
        Show(false);
    }
}