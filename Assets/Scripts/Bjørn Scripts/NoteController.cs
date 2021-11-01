using UnityEngine;

public class NoteController : MonoBehaviour
{
    public AudioClip[] bassNotes;
    public AudioClip[] keyboardNotes;
    public int amountOfInstruments = 2;
    public AudioClip wrongAudio;
    public AudioClip correctAudio;
    private AudioSource noteAudio;

    private void Start()
    {
        noteAudio = GetComponent<AudioSource>();
    }

    public void PlayNote(int note, int instrument)
    {
        switch (instrument)
        {
             case 0:
                if (note > bassNotes.Length)
                {
                    note -= 12;
                }

                noteAudio.PlayOneShot(bassNotes[note - 1]);
                break;
             
             case 1:
                 if (note > keyboardNotes.Length)
                 {
                     note -= 12;
                 }

                 noteAudio.PlayOneShot(keyboardNotes[note - 1]);
                 break;
        }
    }
    
    public void PlayWrong(){
        noteAudio.PlayOneShot(wrongAudio);
    }

    public void PlayCorrect()
    {
        noteAudio.PlayOneShot(correctAudio);
    }
}
