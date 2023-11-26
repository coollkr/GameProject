using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public LuopanPoint frog;
    public LuopanPoint sword;
    public LuopanPoint fan;
   
    public bool IsSolved()
    {

        return (frog.IsSolved() && sword.IsSolved() && fan.IsSolved());   

    }

}
