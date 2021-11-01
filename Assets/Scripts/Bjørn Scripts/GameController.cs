using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private bool PlayedNoteOne;
    private bool PlayedNoteTwo;
    private int Guess;
    private bool HasGuessed;

    private bool PlayingNotes;

    private float timer;
    private float waitBetweenNotes = 2f;
    private float answerTimer;
    [SerializeField] private float setAnswerTimer = 5f;
    [SerializeField] private TMP_Text answerTimerTxt;

    private int usedInterval;
    private int[] intervals = {0, 2, 4, 5, 7, 9, 11, 12};
    private int randomNote;

    [SerializeField] private NoteController _Notes;
    [SerializeField] private TMP_Text isAnswerCorrect;
    private Input _Input;
    private CreateParticle _Particles;

    private float hideTextTimer;
    private float hideTextWait = 2f;

    private string[] intervalNames = {"prim","sekund","ters","kvart","kvint","sekst","septim","oktav"};
    [SerializeField] private Button[] _Buttons;

    private void Start()
    {
        _Input = GetComponent<Input>();
        _Particles = GetComponent<CreateParticle>();
        
        SetGrunntone.SetGrunnTone(Random.Range(1, 13));
    }

    void Update()
    {
        if (answerTimerTxt.IsActive())
        {
            answerTimerTxt.text = Mathf.Ceil(answerTimer).ToString();
        }
        if (GameSetter.useTimer)
        {
            if (answerTimer > 0)
            {
                answerTimer -= Time.deltaTime;
            }
            else if (answerTimerTxt.IsActive())
            {
                TimesUp(waitBetweenNotes);
            }
        }

        if (!PlayingNotes)
        {
            if (HasGuessed)
            {
                if (_Input.hasGuessed) Guess = _Input.digit;
                
                _Input.hasGuessed = false;
                CheckGuess(waitBetweenNotes);
            }
        }

        if (timer <= 0f)
        {
            //Sets a random grunntone
            if (GameSetter.useRandomGrunntone && !PlayedNoteOne && !PlayedNoteTwo)
            {
                SetGrunntone.SetGrunnTone(Random.Range(1, 13));
            }
            
            //Plays notes as a chord
            if (GameSetter.useChord && !PlayedNoteOne)
            {
                PlayNoteOne(0f);
                PlayNoteTwo(waitBetweenNotes);
                if (PlayedNoteOne && PlayedNoteTwo) PlayingNotes = false;

                if (GameSetter.useTimer)
                {
                    answerTimer = setAnswerTimer;
                    answerTimerTxt.gameObject.SetActive(true);
                }
            }
            //Plays notes individually
            else
            {
                //Plays grunntone first
                if (GameSetter.useGrunntoneFirst)
                {
                    if (!PlayedNoteOne) PlayNoteOne(waitBetweenNotes);
                    
                    else if (!PlayedNoteTwo)
                    {
                        PlayNoteTwo(waitBetweenNotes);

                        if (GameSetter.useTimer)
                        {
                            answerTimer = setAnswerTimer;
                            answerTimerTxt.gameObject.SetActive(true);
                        }
                    }
                    else PlayingNotes = false;
                }
                //Plays grunntone last
                else
                {
                    if (!PlayedNoteTwo) PlayNoteTwo(waitBetweenNotes);
                    else if (!PlayedNoteOne)
                    {
                        PlayNoteOne(waitBetweenNotes);

                        if (GameSetter.useTimer)
                        {
                            answerTimer = setAnswerTimer;
                            answerTimerTxt.gameObject.SetActive(true);
                        }
                    }
                    else PlayingNotes = false;
                }
            }
        }
        else timer -= Time.deltaTime;

        if (hideTextTimer <= 0)
        {
            isAnswerCorrect.text = "";
        }
        else hideTextTimer -= Time.deltaTime;
    }

    private void PlayNoteOne(float waitTime)
    {
        PlayedNoteOne = true;
        _Notes.PlayNote(SetGrunntone.grunnTone);
        timer = waitTime;
        
        _Particles.PlayParticles(0, -5f, 5f, 3f, 0f);
    }
    private void PlayNoteTwo(float waitTime)
    {
        PlayedNoteTwo = true;
        HasGuessed = false;
        
        usedInterval = (int)(Mathf.Floor(Random.Range(0, 8)));
        if (usedInterval >= 8) usedInterval = 7;
        
        randomNote = intervals[usedInterval] + SetGrunntone.grunnTone;
        if (randomNote >= _Notes.notes.Length)
        {
            randomNote -= 12;
        }
        _Notes.PlayNote(randomNote);
        timer = waitTime;
        
        _Particles.PlayParticles(1, -5f, 5f, 3f, 0f);
    }

    private void CheckGuess(float waitTime)
    {
        answerTimerTxt.gameObject.SetActive(false);
        if (Guess == usedInterval)
        {
            Correct();
        }
        else
        {
            Wrong();
        }

        PlayedNoteOne = false;
        PlayedNoteTwo = false;
        HasGuessed = true;
        PlayingNotes = true;
        timer = waitTime;
    }

    private void SetGuess(int guess)
    {
        Guess = guess;
        HasGuessed = true;
    }

    private void Correct()
    {
        isAnswerCorrect.text = "Riktig!";
        hideTextTimer = hideTextWait;
    }

    private void Wrong()
    {
        isAnswerCorrect.text = "Feil! Det riktige svaret var " + intervalNames[usedInterval];
        hideTextTimer = hideTextWait;
    }

    private void TimesUp(float waitTime)
    {
        answerTimerTxt.gameObject.SetActive(false);
        isAnswerCorrect.text = "Tiden er ute!";
        hideTextTimer = hideTextWait;
        
        PlayedNoteOne = false;
        PlayedNoteTwo = false;
        HasGuessed = true;
        PlayingNotes = true;
        timer = waitTime;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
