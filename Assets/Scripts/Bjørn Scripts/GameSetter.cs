using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetter : MonoBehaviour
{
    public static string gameType;


    public void SetGameType(string game)
    {
        gameType = game;
    }

    public void StartGameType(string game)
    {
        SetGameType(game);
        SceneManager.LoadScene("BjørnGameTest");
    }
}
