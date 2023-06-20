using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string VERTICAL = "Vertical";
    private const string HORIZONTAL = "Horizontal";

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsBreaking { get; private set; }

    private void Update()
    {
        Vertical = Input.GetAxis(VERTICAL);
        Horizontal = Input.GetAxis(HORIZONTAL);
        IsBreaking = Input.GetKey(KeyCode.Space);
    }
}