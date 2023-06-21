using UnityEngine;
using Zenject;

public class CarController : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [Header("Colliders")]
    [SerializeField] private WheelCollider _frontLeftWheelCollider;
    [SerializeField] private WheelCollider _frontRightWheelCollider;
    [SerializeField] private WheelCollider _rearLeftWheelCollider;
    [SerializeField] private WheelCollider _rearRightWheelCollider;

    [Header("Wheels")]
    [SerializeField] private Transform _frontLeftWheelTransform;
    [SerializeField] private Transform _frontRightWheeTransform;
    [SerializeField] private Transform _rearLeftWheelTransform;
    [SerializeField] private Transform _rearRightWheelTransform;

    [Inject] private InputManager _inputManager;

    private float _currentSteerAngle;
    private float _currentbreakForce;

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        _frontLeftWheelCollider.motorTorque = _inputManager.Vertical * motorForce;
        _frontRightWheelCollider.motorTorque = _inputManager.Vertical * motorForce;
        _currentbreakForce = _inputManager.IsBreaking ? breakForce : 0f;
        ApplyBreakingForce();       
    }

    private void ApplyBreakingForce()
    {
        _frontRightWheelCollider.brakeTorque = _currentbreakForce;
        _frontLeftWheelCollider.brakeTorque = _currentbreakForce;
        _rearLeftWheelCollider.brakeTorque = _currentbreakForce;
        _rearRightWheelCollider.brakeTorque = _currentbreakForce;
    }

    private void HandleSteering()
    {
        _currentSteerAngle = maxSteerAngle * _inputManager.Horizontal;
        _frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        _frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(_frontLeftWheelCollider, _frontLeftWheelTransform, 0);
        UpdateSingleWheel(_frontRightWheelCollider, _frontRightWheeTransform, 180);
        UpdateSingleWheel(_rearRightWheelCollider, _rearRightWheelTransform, 180);
        UpdateSingleWheel(_rearLeftWheelCollider, _rearLeftWheelTransform, 0);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, int angle)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot * Quaternion.Euler(0, angle, 90);
        wheelTransform.position = pos;
    }
}