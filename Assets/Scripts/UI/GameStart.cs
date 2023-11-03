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
        Debug.Log("Click");
        cinematicCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);

    }
}
