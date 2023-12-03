using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *
 * This script is to determine if all three items on the 2nd floor are correctly placed
 *
 */
public class Puzzle2 : MonoBehaviour
{
    public LuopanPoint frog;
    public LuopanPoint sword;
    public LuopanPoint fan;
   
    // If all three points are solved, return true
    public bool IsSolved()
    {
    bool solved = frog.IsSolved() && sword.IsSolved() && fan.IsSolved();
    GameStateManager.Instance.puzzle2Solved = solved;
    return solved; 
    }

    void Update()
    {
        IsSolved();
    }

}
