using UnityEngine;

public class NoteController : MonoBehaviour
{
    public AudioClip[] notes;
    private AudioSource _Audio;

    private void Start()
    {
        _Audio = GetComponent<AudioSource>();
    }

    public void PlayNote(int note)
    {
        _Audio.PlayOneShot(notes[note-1]);
    }
}
