using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<QnA> QnA;

    List<string> rightAnswers = new List<string>();
    List<string> rQuestions = new List<string>();

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
        //В двух строках выше, мы при запуске скрипта включаем GameObject MainGame, а ResultScreen выключаем по ненадобности
        QuestionGenerator();
    }

    public void GameCycle()
    {
        //Debug.Log(roundCounter + " " + roundAmount + " " + score);

        if (roundCounter == roundAmount)
        {
            MainGame.SetActive(false);
            ResultScreen.SetActive(true);
            //Проверяем, если счетчик раундов равен числу раундов в игре, то мы выключаем MainGame и включаем ResultScreen, где мы будем выводить результаты

            rText.text = "Вы ответили правильно на " + score + " из " + roundAmount + " вопросов";

            rightAns += "Список правильных ответов:\n";

            for(int i = 0; i < rightAnswers.Count; i++)
            {
                rightAns += (i + 1) + "Вопрос" + " - " + rightAnswers[i] + "\n"; //Формируем строку, в которой записаны: номер вопроса и правильный ответ
            }

            ansText.text = rightAns; //Выводим список правильных ответов пользователю
        }
        else
        {
            roundCounter++;
            QnA.RemoveAt(currentQuestion);
            QuestionGenerator();
            //Если первое условие не выполнилось, то мы добавляем к счетчику раундов 1, убираем уже отвеченный вопрос и генерируем новый из списка
        }
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
        rQuestions.Add(QnA[currentQuestion].Question.ToString()); //Добавляем вопрос в список
        img.sprite = QnA[currentQuestion].img;//В поле со спрайтом вставляем спрайт нашего вопроса
        SetAnswer();
    }
}