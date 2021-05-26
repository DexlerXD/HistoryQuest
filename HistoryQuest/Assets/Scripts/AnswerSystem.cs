using UnityEngine;

public class AnswerSystem : MonoBehaviour
{

    public bool isCorrect = false;//По началу, переменная которая отвечает за правильность ответа неверна
    public GameManager GameManager;//Переменная, которая представляет собой GameManager, для дальнейшего использования

    public void PickAnswer()
    {
        if (isCorrect == true)
        {
            Debug.Log("Answer is correct");
            GameManager.score++;
            GameManager.GameCycle();
            //Если выбран правильный ответ, то мы добавляем к счетчику очков 1 и вызываем функцию GameCycle в GameManager
        }
        else if (isCorrect == false)
        {
            Debug.Log("Answer is wrong");
            GameManager.GameCycle();
            //Если выбран неправльиный ответ, то мы просто вызвываем функцию GameCycle
        }
        else
        {
            Debug.LogError("Something is wrong!");
            //Если выбранный ответ каким-либо образом не выполняет ни одно из условий то мы выводим ошибку в консоли
        }

    }
}
