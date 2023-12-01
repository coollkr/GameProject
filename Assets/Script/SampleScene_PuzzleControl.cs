using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Candle[] candles;
    public bool IsPuzzleComplete { get; private set; }

    void Update()
    {
        CheckPuzzleCompletion();
    }

    void CheckPuzzleCompletion()
    {
        foreach (Candle candle in candles)
        {
            if (!candle.IsCandleLit) return;
        }
        IsPuzzleComplete = true;
    }
}

