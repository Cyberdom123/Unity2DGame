using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogueSystem : MonoBehaviour
{
    public TMP_Text dialog;
    public Canvas canvas;
    public Rigidbody2D Player;
    private GameObject button;
    private GameObject button1;

    public void Start() //wy³¹cza przyciski i okno dialogowe przy starcie gry
    {
        button = GameObject.Find("Button-Accept");
        button1 = GameObject.Find("Button-Decline");
        button.SetActive(false);
        button1.SetActive(false);

        canvas.enabled = false;
    }
    public void SaySomething(string npcName, string[] dialogText, int dialogTime) //metoda zwracaj¹ca ci¹g
    {                                                                             //wypowiedzi wyœwietlanych na ekranie  
        StartCoroutine(Wait(npcName, dialogTime, dialogText));
    }

    public void PlayerInput() //umo¿liwia u¿ytkowinikowi wprowadzenie danych (obs³uga przycisków)
    {
        button.GetComponent<Button>().onClick.AddListener(HideUI);
        button1.GetComponent<Button>().onClick.AddListener(HideUI);

        button.SetActive(true);
        button1.SetActive(true);
        canvas.enabled = true;
        Player.bodyType = RigidbodyType2D.Static; //uniemo¿liwia poruszenia bohatera

    }

    IEnumerator Wait(string npcName, int time, string[] dialogText)  
                                                                    
    {   
        foreach (string slowo in dialogText)
        {
            canvas.enabled = true;
            dialog.text = npcName + ":\n\n" + slowo;
            Player.bodyType = RigidbodyType2D.Static; //uniemo¿liwia poruszenia bohatera

            yield return new WaitForSeconds(time);
        }
    }

    public void HideUI()
    {
        button.SetActive(false);
        button1.SetActive(false);
        canvas.enabled = false;
        Player.bodyType = RigidbodyType2D.Dynamic; //uniemo¿liwia poruszenia bohatera
    }
}

