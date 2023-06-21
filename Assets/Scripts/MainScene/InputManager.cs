using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<bool> OnBreakPressed;
    public event Action<bool> FrontLightsPressed;

    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;
    private bool _frontLightsEnabled = true;

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
            OnBreakPressed?.Invoke(true);
        }

        if (context.canceled)
        {
            _isBreaking = false;
            OnBreakPressed?.Invoke(false);
        }
    }

    public void LightInput(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _frontLightsEnabled = !_frontLightsEnabled;
            FrontLightsPressed?.Invoke(_frontLightsEnabled);
        }
    }
}