using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrigger : DialogueTrigger
{
    public bool isRcallable;
    public QuestListener questListener; //Quest po ukoñczeniu questa
    public Quest newQuest;

    public override void StartDialog()
    {
        if (newQuest.isActive == true)
        {
            Debug.Log("Quest jest aktywny!"); //Jeœli quest jest aktywny nie wyœwietla questa
        } else if (isRcallable == true && questListener.recall == true)
        {
            base.StartDialog();
        }
        else if (isRcallable == false)
        {
            base.StartDialog();
        }
    }

    public override void Close()
    {
        newQuest.isEnable = true;

        FindObjectOfType<Canvas>().GetComponent<Canvas>().enabled = true;
        if (newQuest.isActive == false)
        {
            FindObjectOfType<DialogueSystem>().PlayerInput();
        }
    }

    public void QuestAccepted()
    {
        if (newQuest.isEnable == true)
        {
            newQuest.isEnable = false;
            newQuest.isActive = true;
            Debug.Log("Quest accepted!");
        }
    }

    public void QuestDeclined()
    {
        if (newQuest.isEnable == true)
        {
            newQuest.isEnable = false;
            newQuest.isActive = false;
            Debug.Log("Quest declined!");
        }
    }

}
