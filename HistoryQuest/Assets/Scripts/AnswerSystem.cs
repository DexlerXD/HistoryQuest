using UnityEngine;

public class AnswerSystem : MonoBehaviour
{
    public bool isCorrect = false;
    public GameManager GameManager;

    public void PickAnswer()
    {
        if (!isCorrect){
            Debug.Log("Answer is wrong");
            GameManager.GameCycle();
            return;
            //Возврат в случае неправильного ответа
        }

        Debug.Log("Answer is correct");
        GameManager.score++;
        GameManager.GameCycle();
    }
}
