using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private readonly int _mainSceneIndex = 1;

    private void Start()
    {
        _startButton.onClick.AddListener(() => { SceneManager.LoadSceneAsync(_mainSceneIndex); });
        _quitButton.onClick.AddListener(() => Application.Quit());
    }
}
