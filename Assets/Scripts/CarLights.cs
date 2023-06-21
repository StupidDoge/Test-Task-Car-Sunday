using UnityEngine;
using Zenject;

public class CarLights : MonoBehaviour
{
    [SerializeField] private Light _rearLeftLight;
    [SerializeField] private Light _rearRightLight;
    [SerializeField] private Light _frontLeftLight;
    [SerializeField] private Light _frontRightLight;

    [Inject] private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager.OnBreakPressed += SetRearLightsActive;
        _inputManager.FrontLightsPressed += SetFrontLightsActive;
    }

    private void OnDisable()
    {
        _inputManager.OnBreakPressed -= SetRearLightsActive;
        _inputManager.FrontLightsPressed -= SetFrontLightsActive;
    }

    private void SetRearLightsActive(bool active)
    {
        _rearRightLight.gameObject.SetActive(active);
        _rearLeftLight.gameObject.SetActive(active);
    }

    private void SetFrontLightsActive(bool active)
    {
        _frontLeftLight.gameObject.SetActive(active); 
        _frontRightLight.gameObject.SetActive(active);
    }
}
