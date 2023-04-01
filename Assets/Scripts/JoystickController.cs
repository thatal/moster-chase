using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    public delegate void JyostickMovememt(string movement);
    public static event JyostickMovememt joystickMoved;

    public void Update()
    {
        if (joystickMoved != null)
        {
            string movement = null;
            if (fixedJoystick.Horizontal > 0)
            {
                movement = "right";
            } else if (fixedJoystick.Horizontal < 0)
            {
                movement = "left";
            }
            joystickMoved(movement);
        }
    }
    public void JumpButtonClicked()
    {
        joystickMoved("jump");
    }
}
