using System;
using UnityEngine;

public class GameTypeLowToHigh : MonoBehaviour
{
    private bool PlayedNoteOne = false;
    private bool PlayedNoteTwo = false;
    private bool HasGuessed = false;

    [SerializeField] private NoteController _Notes;

    // Update is called once per frame
    void Update()
    {
        
    }
}
