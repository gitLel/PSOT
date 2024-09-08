using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    private void Start()
    {
        StorageConfig.boxNumber =  StorageConfig.boxIDNumbers[Random.Range(0, StorageConfig.boxIDNumbers.Count)];

        Debug.Log("Вам нужна коробка: " + StorageConfig.boxNumber);


    }
    
}
