using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    [SerializeField] private List<Transform> stillageSlots;

    private StillageManager stillageManager;

    public void Construct(StillageManager stillageManager)
    {
        this.stillageManager = stillageManager;
    }

    private void Start()
    {
        stillageManager.FillStillage(3);
    }

}
