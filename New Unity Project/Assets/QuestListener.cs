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
        //Je�li quest jest aktywny wy�wietla odpowiedni tekst
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
        //Po wykonaniu questa jest on zaliczony i nie mo�na rozpocz�� nat�pnego (statusId = 3)
        else if (order == 2 && triggeredQuest.isActive == true && triggeredQuest.statusId == 2)
        {
            base.StartDialog();
            triggeredQuest.statusId = 3;
        }
        //Je�li wykona�e� quest, mo�esz rozpocz�� nast�pny
        else if (order == 0 && triggeredQuest.isActive == true && triggeredQuest.statusId == 2)
        {
            base.StartDialog();
            triggeredQuest.statusId = 3;
            StartCoroutine(OrderCooldown());
        } 
    }

    IEnumerator OrderCooldown() //czeka a� zako�czy si� dialog, nst�pnie zaczyna kolejny quest
    {
        int dialogTime = sentenceTime * sentences.Length;
        yield return new WaitForSeconds(dialogTime  + 0.001f); //czeka a� sko�czy si� quest
        Debug.Log("Recall true");
        recall = true;
    }
}
