using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;

    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    public bool IsBreaking => _isBreaking;

    public void ForwardInput(InputAction.CallbackContext context)
    {
        SetAxisInput(context, ref _vertical, 1);
    }

    public void BackwardInput(InputAction.CallbackContext context)
    {
        SetAxisInput(context, ref _vertical, -1);
    }

    public void RightInput(InputAction.CallbackContext context)
    {
        SetAxisInput(context, ref _horizontal, 1);
    }

    public void LeftInput(InputAction.CallbackContext context)
    {
        SetAxisInput(context, ref _horizontal, -1);
    }

    private void SetAxisInput(InputAction.CallbackContext context, ref float axis, float input)
    {
        if (context.started)
        {
            axis = input;
        }

        if (context.canceled)
        {
            axis = 0;
        }
    }

    public void BreakInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isBreaking = true;
        }

        if (context.canceled)
        {
            _isBreaking = false;
        }
    }
}