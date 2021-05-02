using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Starting game session...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //При вызове этой функции программа загружает сцену с индексом на 1 больше чем та, которая была при нажатии этой кнопки
    }

    public void QuitGame()
    {
        Debug.Log("Closing application!");
        Application.Quit();
        //При вызове этой функции программа завершает свою работу
    }
}