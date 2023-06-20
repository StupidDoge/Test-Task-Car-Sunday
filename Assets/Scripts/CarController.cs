using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [Header("Colliders")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [Header("Wheels")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [Header("Other")]
    [SerializeField] private InputManager _inputManager;

    private float currentSteerAngle;
    private float currentbreakForce;

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = _inputManager.Vertical * motorForce;
        frontRightWheelCollider.motorTorque = _inputManager.Vertical * motorForce;
        currentbreakForce = _inputManager.IsBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * _inputManager.Horizontal;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform, 0);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform, 180);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform, 180);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform, 0);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, int angle)
    {
        Vector3 pos;
        Quaternion rot
;       wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot * Quaternion.Euler(0, angle, 90);
        wheelTransform.position = pos;
    }
}
