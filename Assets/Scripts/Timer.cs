using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    //All this function does is cancel the timer if the question is answered early
    public void CancelTimer(){
        timerValue = 0;
    }

    void UpdateTimer(){
        //Reduces the timerValue by 1 second 
        timerValue -= Time.deltaTime;

        //These if statements do several things. If the isAnsweringQuestion is false, it will set to true (bottom else) and set the timer value to timeToCompleteQuestion and start to reduce the fillFraction to fit with the timer going down. Once it hits 0 it will set isAnsweringQuestion back to false, set the timerValue to timeToShowCorrectAnswer and start to reduce the fillFraction again, this time by timeToShowCorrectAnswer
        if(isAnsweringQuestion){
            if(timerValue > 0){
                fillFraction = timerValue / timeToCompleteQuestion;
            } else {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        } else {
            if(timerValue > 0){
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }else{
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnsweringQuestion + ": " + timerValue + "= " + fillFraction);
    }
}
