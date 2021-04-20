using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text qText;

    private void Start()
    {
        QuestionGenerator();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        QuestionGenerator();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerSystem>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerSystem>().isCorrect = true;
            }
        }
    }

    void QuestionGenerator()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        qText.text = QnA[currentQuestion].Question;
        SetAnswer();
    }
}
