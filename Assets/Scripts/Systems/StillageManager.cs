using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillageManager : MonoBehaviour
{
    [SerializeField] private List<Transform> shelfSlots;

    [SerializeField] private GameObject shelfPrefab;

    [SerializeField] private List<BoxSO> boxes;

    private void Start()
    {
        FillStillage(3);
        //FillStillage(UnityEngine.Random.Range(0, 3));
    }
    public void FillStillage(int boxCountForShelf)
    {
        foreach (Transform t in shelfSlots)
        {
            var shelf = Instantiate(shelfPrefab, t.transform);
            var box = GetRandomBox();

            for (int i = 0; i < boxCountForShelf; i++)
            {
                if (shelf.GetComponent<ShelfManager>().TryPlaceBox(box))
                {
                    StorageConfig.boxCount++;
                }
                shelf.GetComponent<ShelfManager>().PlaceBox(box);
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
