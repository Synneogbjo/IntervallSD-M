using UnityEngine;

public class NoteController : MonoBehaviour
{
    public AudioClip[] notes;
    private AudioSource noteAudio;

    private void Start()
    {
        noteAudio = GetComponent<AudioSource>();
    }

    public void PlayNote(int note)
    {
        if (note > notes.Length)
        {
            note -= 12;
        }
        
        noteAudio.PlayOneShot(notes[note-1]);
        print("Note spilt: " + notes[note-1]);
    }
}
