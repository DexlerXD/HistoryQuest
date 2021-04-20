using UnityEngine;

public class AnswerSystem : MonoBehaviour
{

    public bool isCorrect = false;
    public GameManager GameManager;

    public void PickAnswer()
    {
        if (isCorrect == true)
        {
            Debug.Log("Answer is correct");
            GameManager.correct();

        }
        else if (isCorrect == false)
        {
            Debug.Log("Answer is wrong");
        }
        else
        {
            Debug.LogError("Something is wrong!");
        }

    }
}
