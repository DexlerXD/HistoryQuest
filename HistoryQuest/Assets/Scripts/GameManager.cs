using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<QnA> QnA;

    List<string> rightAnswers = new List<string>();

    public GameObject[] options;
    public GameObject MainGame;
    public GameObject ResultScreen;

    public TMP_Text qText;
    public TMP_Text rText;
    public TMP_Text ansText;

    public Image img;

    public AnswerSystem answerSystem;

    public int currentQuestion;
    public int score = 0;
    private int roundCounter = 1;
    public int roundAmount = 5;

    private string rightAns;


    private void Start()
    {
        MainGame.SetActive(true); 
        ResultScreen.SetActive(false);
        //В двух строках выше, при загрузке сцены включаем GameObject MainGame, а ResultScreen выключаем по ненадобности
        QuestionGenerator();
    }

    public void GameCycle()
    {
        if (roundCounter != roundAmount)
        {
            roundCounter++;
            QnA.RemoveAt(currentQuestion);
            QuestionGenerator();
            return;
            //Если счетчик раундов не равен общему количеству раундов, то инкрементируем счетчик и возвращаем void
        }

        MainGame.SetActive(false);
        ResultScreen.SetActive(true);

        rText.text = "Вы ответили правильно на " + score + " из " + roundAmount + " вопросов";
        //Выводим, на сколько вопросов правильно ответил пользователь

        rightAns += "Список правильных ответов:\n";

        for(int i = 0; i < rightAnswers.Count; i++)
        {
            rightAns += (i + 1) + "Вопрос" + " - " + rightAnswers[i] + "\n"; //Формируем строку, в которой записаны: номер вопроса и правильный ответ
        } 

        ansText.text = rightAns; //Выводим список правильных ответов пользователю
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //Используем цикл for чтобы перебрать все ответы к одному вопросу

            options[i].GetComponent<AnswerSystem>().isCorrect = false; //По стандарту, делаем выбранный ответ неправильным
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
            //Этот же выбранный вопрос мы вставляем в поле с выбором ответа при помощи GetComponent<> и выбором техта из нашего списка

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerSystem>().isCorrect = true;
                rightAnswers.Add(QnA[currentQuestion].Answers[i].ToString()); //Добавляем правильный ответ в список 

                //Проводится проверка: Если номер выбранного программой ответа совпадает с номером правльного, то этот ответ помечается как правильный
            }
        }
    }

    void QuestionGenerator()
    {
        currentQuestion = Random.Range(0, QnA.Count);//Генерируем число от 0 до числа вопросов
        qText.text = QnA[currentQuestion].Question;//В поле вопроса вставляем текст нашего вопроса.
        img.sprite = QnA[currentQuestion].img;//В поле со спрайтом вставляем спрайт нашего вопроса
        SetAnswer();
    }
}