using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class JulianTestScript : MonoBehaviour
{
    public int questionNumber;
    
    private string m_Question;
    
    [SerializeField] private int howManyQuestions = 8;
    
    public TMP_Text questionHeader;

    public List<string> trueAnswer = new List<string>();

    public List<string> falseAnswer = new List<string>();

    public string[] buttons;

    private int CurrentIndex = -1;

    public GameObject selectedButton;
    
    public int rightAnswer;

    private void Start()
    {
        RestartQuestioning();
        
    }

    private void RestartQuestioning()
    {
        questionNumber = (Random.Range(1, howManyQuestions));

        falseAnswer.Add("Prim");
        falseAnswer.Add("Sekund");
        falseAnswer.Add("Ters");
        falseAnswer.Add("Kvart");
        falseAnswer.Add("Kvint");
        falseAnswer.Add("Sekst");
        falseAnswer.Add("Septim");
        falseAnswer.Add("Oktav");
        
        QuestionBank();
    }

    public void QuestionBank()
    {
        // A
        if (questionNumber == 1)
        {
            m_Question = "Prim";
            trueAnswer.Add("Prim");
            falseAnswer.Remove("Prim");

            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3));
            Answers();
        }
        
        // B
        else if (questionNumber == 2)
        {
            m_Question = "Sekund";
            trueAnswer.Add("Sekund");
            falseAnswer.Remove("Sekund");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3));
            Answers();
        }
        
        // C
        else if (questionNumber == 3)
        {
            m_Question = "Ters";
            trueAnswer.Add("Ters");
            falseAnswer.Remove("Ters");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3));
            Answers();
        }
        
        // D
        else if (questionNumber == 4)
        {
            m_Question = "Kvart";
            trueAnswer.Add("Kvart");
            falseAnswer.Remove("Kvart");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3)); ;
            Answers();
        }
        
        // E
        else if (questionNumber == 5)
        {
            m_Question = "Kvint";
            trueAnswer.Add("Kvint");
            falseAnswer.Remove("Kvint");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3)); ;
            Answers();
        }
        
        // F
        else if (questionNumber == 6)
        {
            m_Question = "Sekst";
            trueAnswer.Add("Sekst");
            falseAnswer.Remove("Sekst");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3)); ;
            Answers();
        }
        
        // G
        else if (questionNumber == 7)
        {
            m_Question = "Septim";
            trueAnswer.Add("Septim");
            falseAnswer.Remove("Septim");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3)); ;
            Answers();
        }
        
        // H
        else if (questionNumber == 8)
        {
            m_Question = "Oktav";
            trueAnswer.Add("Oktav");
            falseAnswer.Remove("Oktav");
            
            // Assigns which button is correct between button 0 and button 3
            rightAnswer = (Random.Range(0, 3)); ;
            Answers();
        }
        
        SetQuestion(questionHeader);
    }

    private void Answers()
    {
        for (int i = 0; i < buttons.Length ; i++)
        {
            if (i == rightAnswer)
            {
                buttons[i] = trueAnswer[0];
            }
            else
            {
                int wrongAnswer = Random.Range(0, falseAnswer.Count - 1);
                buttons[i] = falseAnswer[wrongAnswer];
                falseAnswer.RemoveAt(wrongAnswer);
            }
        }
    }

    public void SetQuestion(TMP_Text text)
    {
        text.text = "Which is " + m_Question;
    }

    public void SetButtonIndex(int index)
    {
        CurrentIndex = index;
        print(CurrentIndex);
        PlayNote(buttons[CurrentIndex]);
    }

    private void PlayNote(string note)
    {
        
    }

    public void Confirm()
    {
        // Plays when the button is pressed
        //if (rightAnswer == CurrentIndex)
        
        //m_ConfirmButton = true;
        if (CurrentIndex == -1)
        {
            // could be return function
            print("Please select a Button");
        }
        else if (rightAnswer == CurrentIndex)
        {
            print("You sucededded");
            
            trueAnswer.Clear();
            falseAnswer.Clear();
            Start();
            CurrentIndex = -1;
        }
        else
        {
            print("you f'd up");
            
            trueAnswer.Clear();
            falseAnswer.Clear();
            Start();
            CurrentIndex = -1;
        }
    }
    
    //buttons[0].GetComponentInChildren<TMP_Text>().text = " hello";
    
    /*
    public void OnClickCheckForCorrectAnswer()
    {
        selectedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        for (var index = 0; index < buttons.Length; index++)
        {
            if (selectedButton.name == buttons[index].name)
            {
                if (index == rightAnswer)
                {
                    // You chose Correctly
                    print("correct Answer");
                    //Start();
                }
                else
                {
                    // You chose poorly
                    print("Not correct Answer");
                    //Start();
                }
            }
        }
    }
    */
}
