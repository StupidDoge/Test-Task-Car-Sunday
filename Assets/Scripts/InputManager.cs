using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string VERTICAL = "Vertical";
    private const string HORIZONTAL = "Horizontal";

    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public bool IsBreaking { get; set; }

    private void Update()
    {
        Vertical = Input.GetAxis(VERTICAL);
        Horizontal = Input.GetAxis(HORIZONTAL);
        IsBreaking = Input.GetKey(KeyCode.Space);
    }
}
