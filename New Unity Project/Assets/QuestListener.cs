using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListener : DialogueTrigger
{
    public QuestTrigger questTrigger;

    public bool recall = false;
    public int order;

    public override void StartDialog()
    {
        //Jeœli quest jest aktywny wyœwietla odpowiedni tekst
        Quest triggeredQuest = questTrigger.newQuest;

        if (order == 1 && triggeredQuest.isActive == true && triggeredQuest.statusId == 1)
        {
            base.StartDialog();
            triggeredQuest.statusId = 2;
        }
        //Pomija quest
        else if (order == 3 && triggeredQuest.isActive == true && triggeredQuest.statusId == 1)
        {
            triggeredQuest.statusId = 2;
        }
        //Po wykonaniu questa jest on zaliczony i nie mo¿na rozpocz¹æ natêpnego (statusId = 3)
        else if (order == 2 && triggeredQuest.isActive == true && triggeredQuest.statusId == 2)
        {
            base.StartDialog();
            triggeredQuest.statusId = 3;
        }
        //Jeœli wykona³eœ quest, mo¿esz rozpocz¹æ nastêpny
        else if (order == 0 && triggeredQuest.isActive == true && triggeredQuest.statusId == 2)
        {
            base.StartDialog();
            triggeredQuest.statusId = 3;
            StartCoroutine(OrderCooldown());
        } 
    }

    IEnumerator OrderCooldown() //czeka a¿ zakoñczy siê dialog, nstêpnie zaczyna kolejny quest
    {
        int dialogTime = sentenceTime * sentences.Length;
        yield return new WaitForSeconds(dialogTime  + 0.001f); //czeka a¿ skoñczy siê quest
        Debug.Log("Recall true");
        recall = true;
    }
}
