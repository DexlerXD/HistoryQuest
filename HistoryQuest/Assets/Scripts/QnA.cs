using UnityEngine;

[System.Serializable]

public class QnA
{
    public string Question;//Строчка, отвечающая за вопрос
    public string[] Answers;//Массив, содержащий в себе ответы
    public int CorrectAnswerIndex;//Число, соедржащее номер правильного ответа
    public Sprite img;//Спрайт, содержащий картинку к вопросу
}
