using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private bool PlayedNoteOne;
    private bool PlayedNoteTwo;
    private int Guess;
    private bool HasGuessed;

    private float timer;
    private float waitBetweenNotes = 2f;

    private int usedInterval;
    private int[] intervals = {1,3,5,6,8,10,12,13};
    private int randomNote;
    
    [SerializeField] private NoteController notes;
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
        if (_Input.hasGuessed)
        {
            Guess = _Input.digit;
            _Input.hasGuessed = false;
            CheckGuess();
        }
        
        if (timer <= 0f)
        {
            if (!PlayedNoteOne) PlayNoteOne();
            else if (!PlayedNoteTwo) PlayNoteTwo();
            else if (HasGuessed) CheckGuess();
        }
        else timer -= Time.deltaTime;

        if (hideTextTimer <= 0)
        {
            isAnswerCorrect.text = "";
        }
        else hideTextTimer -= Time.deltaTime;
    }

    private void PlayNoteOne()
    {
        PlayedNoteOne = true;
        notes.PlayNote(SetGrunntone.grunnTone);
        timer = waitBetweenNotes;
        print(SetGrunntone.grunnTone);
    }
    private void PlayNoteTwo()
    {
        PlayedNoteTwo = true;
        HasGuessed = false;
        
        usedInterval = (int)(Mathf.Floor(Random.Range(0, 8)));
        if (usedInterval >= 8) usedInterval = 7;
        
        randomNote = intervals[usedInterval];
        notes.PlayNote(randomNote);
        timer = waitBetweenNotes;
        print(randomNote);
    }

    private void CheckGuess()
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
        timer = waitBetweenNotes;
    }

    private void SetGuess(int guess)
    {
        Guess = guess;
        CheckGuess();
    }

    private void Correct()
    {
        isAnswerCorrect.text = "Correct!";
        hideTextTimer = hideTextWait;
    }

    private void Wrong()
    {
        isAnswerCorrect.text = "Wrong!";
        hideTextTimer = hideTextWait;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
