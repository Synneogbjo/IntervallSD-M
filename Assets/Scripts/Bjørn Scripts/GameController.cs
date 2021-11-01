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
    public bool HasGuessed;
    private bool justSwappedGuess;
    private bool justActivatedButtons;

    private bool PlayingNotes = true;
    private int instrument;

    private float timer = 1f;
    private float waitBetweenNotes = 2f;
    private float answerTimer;
    [SerializeField] private float setAnswerTimer = 5f;
    [SerializeField] private TMP_Text answerTimerTxt;

    private int usedInterval;
    private int[] intervals = {0, 2, 4, 5, 7, 9, 11, 12};
    private int randomNote;

    [SerializeField] private NoteController _Notes;
    [SerializeField] private TMP_Text isAnswerCorrect;
    private CreateParticle _Particles;

    private float hideTextTimer;
    private float hideTextWait = 2f;

    private string[] intervalNames = {"prim","sekund","ters","kvart","kvint","sekst","septim","oktav"};
    [SerializeField] private Button[] _Buttons;

    private void Start()
    {
        _Particles = GetComponent<CreateParticle>();

        instrument = GameSetter.mainInstrument;
        SetGrunntone.SetGrunnTone(Random.Range(1, 13));
    }

    void Update()
    {
        if (PlayingNotes && justActivatedButtons)
        {
            justActivatedButtons = false;
            foreach (Button btn in _Buttons)
            {
                btn.interactable = false;
            }
        }
        else if (!justActivatedButtons)
        {
            justActivatedButtons = true;
            
            foreach (Button btn in _Buttons)
            {
                btn.interactable = true;
                if (GameSetter.useTimer)
                {
                    answerTimer = setAnswerTimer;
                    answerTimerTxt.gameObject.SetActive(true);
                }
            }
        }
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
            if (HasGuessed && Guess >= 0)
            {
                CheckGuess(waitBetweenNotes);
            }
        }

        if (timer <= 0f)
        {
            if (!PlayingNotes && !justSwappedGuess)
            {
                HasGuessed = false;
                justSwappedGuess = true;
            }

            //Sets a random grunntone
            if (GameSetter.useRandomGrunntone && !PlayedNoteOne && !PlayedNoteTwo)
            {
                SetGrunntone.SetGrunnTone(Random.Range(1, 13));
            }
            
            //Plays notes as a chord
            if (GameSetter.useChord)
            {
                if (PlayedNoteOne && PlayedNoteTwo) PlayingNotes = false;

                if (!PlayedNoteOne)
                {
                    PlayNoteOne(0f);
                    instrument += 1;

                    if (instrument >= _Notes.amountOfInstruments)
                    {
                        instrument = 0;
                    }
                    PlayNoteTwo(waitBetweenNotes);
                    instrument = GameSetter.mainInstrument;
                }
            }

            //Plays notes individually
            if (!GameSetter.useChord)
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
        
        _Notes.PlayNote(SetGrunntone.grunnTone, instrument);
        timer = waitTime;
        
        _Particles.PlayParticlesAt(0, -5f, 5f, 3f, 0f);
    }
    private void PlayNoteTwo(float waitTime)
    {
        PlayedNoteTwo = true;

        usedInterval = (int)(Mathf.Floor(Random.Range(0, 8)));
        if (usedInterval >= 8) usedInterval = 7;
        
        randomNote = intervals[usedInterval] + SetGrunntone.grunnTone;
        _Notes.PlayNote(randomNote, instrument);
        timer = waitTime;
        
        _Particles.PlayParticlesAt(1, -5f, 5f, 3f, 0f);
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
        justSwappedGuess = false;
        PlayingNotes = true;
        Guess = -1; //Resets the guess, making sure that the game doesn't use your last guess for the next question
        timer = waitTime;
    }

    public void SetGuess(int guess)
    {
        if (!PlayingNotes)
        {
            Guess = guess;
            HasGuessed = true;
        }
    }

    private void Correct()
    {
        _Notes.PlayCorrect();
        _Particles.PlayStarParticles();
        isAnswerCorrect.text = "Riktig!";
        hideTextTimer = hideTextWait;
    }

    private void Wrong()
    {
        _Notes.PlayWrong();
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