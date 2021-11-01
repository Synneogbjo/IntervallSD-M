using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestScript
{
    public class MusicController : MonoBehaviour
    {
        [Header("Changes order of the Interval")]
        [Tooltip("if True, Ascend, else, Descend")]
        public AscendDescend ascendDescend;
        public enum AscendDescend
        {
            Ascend,
            Descend
        }
        [HideInInspector] public bool ascendOrDescend;
        
        
        [Header("Instrument")]
        [Tooltip("Bass = 1, Piano = 2")]
        [SerializeField] private int firstInstrument = 1;
        [Tooltip("Bass = 1, Piano = 2")]
        [SerializeField] private int secondInstrument = 2;

        [Header("Notes")]
        public AudioClip[] pianoNotes;
        public AudioClip[] bassNotes;
        
        private int m_BaseNote;
        
        [Header("Intervals")]
        [SerializeField]private readonly int[] m_Intervals = {0,2,4,5,7,9,11,12};
        [SerializeField]public string[] intervalsStrings;
        
        [Header("Components")]
        public AudioSource audioSource;
        
        [Header("Timer")]
        [SerializeField] private float waitBetweenNotes = 2f;
        
        private void Update()
        {
            ascendDescend = ascendOrDescend ? AscendDescend.Ascend : AscendDescend.Descend;
        }

        public void SetBaseNote()
        {
            int tone = Random.Range(1, bassNotes.Length)-1;
            m_BaseNote = tone;
        }

        public void TranslateStrings(string interval)
        {
            for (int i = 0; i < intervalsStrings.Length; i++)
            {
                if (interval == intervalsStrings[i])
                {
                    int secondNote = m_BaseNote + i;
                    StartCoroutine(IntervalWait(m_BaseNote, secondNote));
                    
                    //PlayNote(intervals[secondNote]);
                }
            }
        }

        private IEnumerator IntervalWait(int note1, int note2)
        {
            if (ascendDescend == AscendDescend.Ascend)
            {
                print(note1);
                PlayNote(note1, firstInstrument);
                yield return new WaitForSeconds(waitBetweenNotes);
                print(note2);
                PlayNote(m_Intervals[note2],secondInstrument);
            }
            else if (ascendDescend == AscendDescend.Descend)
            {
                print(note2);
                PlayNote(note2, firstInstrument);
                yield return new WaitForSeconds(waitBetweenNotes);
                print(note1);
                PlayNote(m_Intervals[note1], secondInstrument);
            }
        }
            
        private void PlayNote(int note, int instrument)
        {
            if (instrument == 1)
            {
                audioSource.PlayOneShot(bassNotes[note]);
                print("bassNote spilt: " + bassNotes[note]);
            }
            else
            {
                audioSource.PlayOneShot(pianoNotes[note]);
                print("pianoNote spilt: " + pianoNotes[note]);
            }
            /*
            if (note > notes.Length)
            {
                note -= 12;
            }
        
            audioSource.PlayOneShot(notes[note]);
            print("Note spilt: " + notes[note]);*/
        }
    }
}
