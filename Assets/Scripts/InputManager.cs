using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsBreaking { get; private set; }

    public void ForwardInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vertical = 1;
        }

        if (context.canceled)
        {
            Vertical = 0;
        }
    }

    public void BackwardInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vertical = -1;
        }

        if (context.canceled)
        {
            Vertical = 0;
        }
    }

    public void RightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Horizontal = 1;
        }

        if (context.canceled)
        {
            Horizontal = 0;
        }
    }

    public void LeftInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Horizontal = -1;
        }

        if (context.canceled)
        {
            Horizontal = 0;
        }
    }

    public void BreakInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsBreaking = true;
        }

        if (context.canceled)
        {
            IsBreaking = false;
        }
    }
}