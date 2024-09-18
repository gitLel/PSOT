using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    bool isFull = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            isFull = !isFull;

            foreach (var item in StorageConfig.boxIDNumbers)
            {
                Debug.Log(item);

            }
        }

        if(isFull)
        {
            StorageConfig.currentBoxNumber = StorageConfig.boxIDNumbers[Random.Range(0, StorageConfig.boxIDNumbers.Count)];

            Debug.Log("Вам нужна коробка: " + StorageConfig.currentBoxNumber);


            foreach (var box in StorageConfig.boxIDNumbers)
            {
                Debug.Log(box);
            }

            isFull = false;
        }
    }

}
