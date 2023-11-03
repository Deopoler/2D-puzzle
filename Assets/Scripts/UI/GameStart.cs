using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public Canvas canvas;
    public Camera cinematicCamera;
    public Camera mainCamera;
    public void StartGame()
    {
        canvas.gameObject.SetActive(false);
        cinematicCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);

    }
}
