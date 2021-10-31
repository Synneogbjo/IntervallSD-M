using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private int usedInterval;
    private int[] intervals = {0,2,4,5,7,9,11,12};
    private int randomNote;
    
    [SerializeField] private NoteController _Notes;
    [SerializeField] private TMP_Text isAnswerCorrect;
    private Input _Input;

    private float hideTextTimer;
    private float hideTextWait = 2f;

    private void Start()
    {
        _Input = GetComponent<Input>();
    }

    void Update()
    {
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
            if (!PlayedNoteOne) PlayNoteOne(waitBetweenNotes);
            else if (!PlayedNoteTwo) PlayNoteTwo(waitBetweenNotes);
            else PlayingNotes = false;
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
    }

    private void CheckGuess(float waitTime)
    {
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
        isAnswerCorrect.text = "Correct!";
        hideTextTimer = hideTextWait;
    }

    private void Wrong()
    {
        isAnswerCorrect.text = Guess + ":" + usedInterval;
        hideTextTimer = hideTextWait;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
