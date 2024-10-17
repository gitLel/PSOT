using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator 
{
    public int GetNumber()
    {
        return Random.Range(1000, 9999);
    }
}
