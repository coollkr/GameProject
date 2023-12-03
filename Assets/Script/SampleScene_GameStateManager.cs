using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public int totalCandles = 4;
    private int litCandles = 0;
    public bool puzzle2Solved = false;

    public GameObject latern; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (puzzle2Solved && !latern.activeSelf)
        {
            latern.SetActive(true); 
        }
    }

    public void CandleLit()
    {
        litCandles++;
    }

    public bool AreAllCandlesLit()
    {
        return litCandles == totalCandles;
    }

    public bool AreAllPuzzlesSolved()
    {
        return AreAllCandlesLit() && puzzle2Solved;
    }
}
