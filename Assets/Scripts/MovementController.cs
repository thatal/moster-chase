using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public delegate void PlayerMoved(string buttonName);
    public static event PlayerMoved playerMovementButtonClicked;
    [SerializeField]
    private GameObject movementController;
    private void Awake()
    {
       /* if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            movementController.SetActive(true);
        }
        else
        {
            movementController.SetActive(false);
        }*/
    }
    public void LeftButtonClicked()
    {
        MoveButtonClicked("left");
    }
    public void RightButtonClicked()
    {
        MoveButtonClicked("right");
    }
    public void JumpButtonClicked()
    {
        MoveButtonClicked("jump");
    }
    public void ButtonPressReleased()
    {
        MoveButtonClicked("released");
    }
    private void MoveButtonClicked(string buttonName)
    {
        if (playerMovementButtonClicked != null)
        {
            playerMovementButtonClicked(buttonName);
        }
    }
}

