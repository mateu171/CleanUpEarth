using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject shop;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void ComeBack()
    {
        game.SetActive(true);
        shop.SetActive(false);
    }

    public void OpenShop()
    {
        game.SetActive(false);
        shop.SetActive(true);
    }
}
