using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerGameObject; //zwraca wsp�rz�dne gracza

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120; //ustaiwa limit fps na 120

        Camera.main.backgroundColor = Color.black; //zmienia kolor t�a na czarny
    }
    void Update() //kamera �ledzi bohatera poprzez wisywanie od jej pozycji koordynat�w gracza (d�ugo��, szerko��, wysko��)
    {
        Camera.main.transform.position = new Vector3(playerGameObject.position.x, playerGameObject.position.y, -10);
    }
}
