using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StorageConfig", menuName = "Configs/StorageConfig")]
public class StorageConfig : ScriptableObject
{
    
    public GameObject box;
    
    public static int boxCount = 0;

    public static List<int> boxIDNumbers = new(0);

    public static string GetID()
    {
        var lenght = StorageConfig.boxIDNumbers.Count;
        var id = StorageConfig.boxIDNumbers[UnityEngine.Random.Range(0, lenght)].ToString();
        return id;
    }
}
