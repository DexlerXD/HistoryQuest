using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<QnA> QnA;
    //Мы проебразуем созданный вручную класс QnA в список объектов

    public GameObject[] options;
    public GameObject MainGame;
    public GameObject ResultScreen;
    //Объявляем нужные нам GameObject, что бы с ними можно было работать далее. Назначение некоторых объектов происходит в инспекторе Unity.

    public TMP_Text qText;
    public TMP_Text rText;
    //Объявляем два поля для ввода техта qText - поле для текста вопроса, а rText поле для результатов в конце игры

    public Image img;
    //Объявляем переменную типа Image для работы со спрайтами

    public AnswerSystem answerSystem;
    //Объявляем переменную, которая будет представлять собой скрипт AnswerSystem

    public int currentQuestion;
    public int score = 0;
    private int roundCounter = 1;
    public int roundAmount = 5;
    //Объявляем все необходимые числовые переменные

    private void Start()
    {
        MainGame.SetActive(true); 
        ResultScreen.SetActive(false);
        //В двух строках выше, мы при запуске скрипта включаем GameObject MainGame, а ResultScreen выключаем по ненадобности
        QuestionGenerator();
    }

    public void GameCycle()
    {
        Debug.Log(roundCounter + " " + roundAmount + " " + score);
        //Строчка, нужная для отладки в юнити

        if (roundCounter == roundAmount)
        {
            MainGame.SetActive(false);
            ResultScreen.SetActive(true);
            //Проверяем, если счетчик раундов равен числу раундов в игре, то мы выключаем MainGame и включаем ResultScreen, где мы будем выводить результаты

            rText.text = "Вы ответили на " + score + " из " + roundAmount + " вопросов";
            //Код, формирующий результат игрока
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
