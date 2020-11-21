using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeyListeningManager : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.characterController == null) return;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            GameManager.instance.characterController.Move(Direction.North);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GameManager.instance.characterController.Move(Direction.East);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GameManager.instance.characterController.Move(Direction.South);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GameManager.instance.characterController.Move(Direction.West);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) &&
           !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) &&
           !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow))
        {
            GameManager.instance.characterController.StopMoving();
        }
    }

}
