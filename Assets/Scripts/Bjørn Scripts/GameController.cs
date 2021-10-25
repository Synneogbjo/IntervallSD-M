using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (GameSetter.gameType)
        {
            case "LowToHigh":
                gameObject.AddComponent<GameTypeLowToHigh>();
                break;
            case "HighToLow":
                gameObject.AddComponent<GameTypeHighToLow>();
                break;
            default:
                print("i dont know what this is");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
