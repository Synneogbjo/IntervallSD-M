using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetter : MonoBehaviour
{
    public static bool useRandomGrunntone;
    public static bool useChord;
    public static bool useGrunntoneFirst = true;
    public static bool useTimer;


    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DoRandomGrunntone(bool i)
    {
        useRandomGrunntone = i;
    }

    public void DoChord(bool i)
    {
        useChord = i;
    }

    public void DoGrunntoneFirst(bool i)
    {
        useGrunntoneFirst = i;
    }

    public void DoTimer(bool i)
    {
        useTimer = i;
    }
    
}
