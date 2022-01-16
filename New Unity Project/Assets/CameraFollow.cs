using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerGameObject; //zwraca wspó³rzêdne gracza

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120; //ustaiwa limit fps na 120

        Camera.main.backgroundColor = Color.black; //zmienia kolor t³a na czarny
    }
    void Update() //kamera œledzi bohatera poprzez wisywanie od jej pozycji koordynatów gracza (d³ugoœæ, szerkoœæ, wyskoœæ)
    {
        Camera.main.transform.position = new Vector3(playerGameObject.position.x, playerGameObject.position.y, -10);
    }
}
