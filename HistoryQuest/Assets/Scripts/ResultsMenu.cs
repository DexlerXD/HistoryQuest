using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Starting game session...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //При вызове этой функции программа загружает ту же сцены что была при нажатии этой кнопки
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //При вызове этой функции программа загружает сцену с индексом на 1 меньше чем та, которая была при нажатии этой кнопки
    }
}