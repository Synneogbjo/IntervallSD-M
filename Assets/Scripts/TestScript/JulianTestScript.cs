using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestScript
{
    public class JulianTestScript : MonoBehaviour
    {
        public int questionNumber;
    
        private string m_Question;
        
        public TMP_Text questionHeader;
    
        public int currentIndex = -1;

        public GameObject selectedButton;
    
        public int rightAnswer;
    
        [Header("Lists")]

        public List<string> trueAnswer = new List<string>();

        public List<string> falseAnswer = new List<string>();
    
        //public List<int> baseNote = new List<int>();

        public string[] buttons;

        public MusicController noteController;
        public GameSetter gameSetter;

        private void Start()
        {
            RestartQuestioning();
        }
        
        private void RestartQuestioning()
        {
            // Must contain all answer alternatives
            for (int i = 0; i < noteController.intervalsStrings.Length; i++)
            {
                falseAnswer.Add(noteController.intervalsStrings[i]);
            }
            
            questionNumber = (Random.Range(1, falseAnswer.Count))-1;
            
            QuestionBank();
            //if (!gameSetter.UseRandomGrunntone) return;
            noteController.SetBaseNote();
        }

        private void QuestionBank()
        {
            string answer = falseAnswer[questionNumber]; 
            
            m_Question = answer;
            trueAnswer.Add(answer);
            falseAnswer.Remove(answer);
            
            rightAnswer = (Random.Range(0, 3));
            Answers();

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

        private void SetQuestion(TMP_Text text)
        {
            text.text = "Which is " + m_Question;
        }

        public void SetButtonIndex(int index)
        {
            currentIndex = index;
            print(currentIndex);
            noteController.TranslateStrings(buttons[currentIndex]);
        }
        
        public void Confirm()
        {
            // Plays when the button is pressed
            //if (rightAnswer == CurrentIndex)
        
            //m_ConfirmButton = true;
            if (currentIndex == -1)
            {
                // could be return function
                print("Please select a Button");
            }
            else if (rightAnswer == currentIndex)
            {
                print("You Suck-seeded");
            
                trueAnswer.Clear();
                falseAnswer.Clear();
                Start();
                currentIndex = -1;
            }
            else
            {
                print("you f'd up");
            
                trueAnswer.Clear();
                falseAnswer.Clear();
                Start();
                currentIndex = -1;
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
}
