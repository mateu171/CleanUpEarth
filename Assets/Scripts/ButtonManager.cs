using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitSettings()
    {
        settingsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void ComeInSettings()
    {
        settingsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
}
