using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueTrigger : MonoBehaviour
{

    public string npcName;

    public string[] sentences;

    public int sentenceTime = (int)2f;

    private bool cooldownTime = false;


    private void OnTriggerEnter2D(Collider2D collision) //metoda urochamina przy kolizji bohatera z npc
    {
        StartDialog();
    }

    public virtual void StartDialog()
    {
        int dialogTime = sentenceTime * sentences.Length;
        if (cooldownTime == false)
        {
            StartCoroutine(Cooldown(dialogTime));
            FindObjectOfType<DialogueSystem>().SaySomething(npcName, sentences, sentenceTime);
        }
    }

    IEnumerator Cooldown(int dialogTime)
    {
        cooldownTime = true;
        yield return new WaitForSeconds(dialogTime - sentenceTime);
        Close();
        yield return new WaitForSeconds(dialogTime + 0.2F);
        cooldownTime = false;
        Debug.Log("Cooldown stop");
    }

    public virtual void Close()
    {
        StartCoroutine(CloseUI());
    }

    IEnumerator CloseUI()
    {
        yield return new WaitForSeconds(sentenceTime);
        Debug.Log("Dialog closed");
        FindObjectOfType<DialogueSystem>().HideUI();
    }
}
