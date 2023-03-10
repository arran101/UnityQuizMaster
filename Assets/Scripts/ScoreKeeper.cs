using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int correctAnswers = 0;
    int questionsSeen = 0;
    
    //These are the getters and setters, basically instead of making the above ints public, we make these functions public to protect the ints themselves
    public int GetCorrectAnswers(){
        return correctAnswers;
    }

    public void IncrementCorrectAnswers(){
        correctAnswers++;
    }
    public int GetQuestionsSeen(){
        return questionsSeen;
    }

    public void IncrementQuestionsSeen(){
        questionsSeen++;
    }

    public int CalculateScore(){
        //so if you divide an int by another int(doesn't show decimal numbers), instead of giving fractions it will return 0. So we change one of the ints into a float (does show decimal numbers) and then round it back to an int after the math is done, so we get a nice clean score
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
    }
}
