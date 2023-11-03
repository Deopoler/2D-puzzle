using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 targetPos;
    public Vector3 startPos;
    public float speed = 1.0f;

    private Vector3 target;
    private bool targetChecked = false;

    void OnEnable()
    {
        target = targetPos;
        transform.position = startPos;
    }
    private void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            if (!targetChecked)
            {
                target = startPos;
                targetChecked = true;
            }
            else
            {
                mainCamera.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
