using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] positions;
    private int currentPosition;
    private bool changingPositions;
    private float lerpTime = 1f;
    private float currentLerpTime;
    private Vector3 startPos, endPos;

    private void Start()
    {
        currentPosition = 0;
    }

    private void Update()
    {
        if (changingPositions)
        {
            transform.position = positions[currentPosition].position;
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                changingPositions = false;
            }
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
        }
    }

    public void ChangePositions()
    {
        currentPosition = currentPosition == 0 ? 1 : 0;
        currentLerpTime = 0;
        changingPositions = true;
        startPos = transform.position;
        endPos = positions[currentPosition].position;
        transform.position = positions[currentPosition].position;
        GameManager.instance.characterController.transform.position =
           positions[currentPosition].position;
    }
}
