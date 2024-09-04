using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    [SerializeField] private List<Transform> shelfSlots;
    [SerializeField] private GameObject shelfPrefab;

    [SerializeField] private List<BoxSO> boxes;

    private StorageConfig storageConfig;
    private int maxSpawnBox = 3;

    private void Start()
    {
        foreach (Transform t in shelfSlots)
        {
            var shelf = Instantiate(shelfPrefab, t.transform);
            var box = GetRandomBox();

            for(int i = 0; i < maxSpawnBox; i++)
            {
                if (shelf.GetComponent<Shelf>().TryPlaceBox(box))
                {
                    StorageConfig.boxCount++;
                }
                shelf.GetComponent<Shelf>().PlaceBox(box);
                shelf.transform.localPosition = Vector3.zero;
            }
        }
    }

    
    

    private BoxSO GetRandomBox()
    {
        int random = UnityEngine.Random.Range(0, 3);
        return boxes[random];
    }

}
