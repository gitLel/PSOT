using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    [SerializeField] private List<Transform> slotsTransform;

    [SerializeField] private List<bool> slots;

    public static GameObject currentBoxPrefab;
    
    public void PlaceBox(Box box)
    {
        if (TryPlaceBox(box))
        {

            currentBoxPrefab = Instantiate(box.gameObject, this.transform);
            currentBoxPrefab.transform.position = GetCorrectPlacementBox(box).position;

            SetNumberIDForBox(box);

            ChaoticRotateBox(currentBoxPrefab);

            FillOrClearSlots(box, true);
        }

    }

    private static void SetNumberIDForBox(Box box)
    {
        box.boxNumberID = Random.Range(1000, 9999);
        StorageConfig.boxIDNumbers.Add(box.boxNumberID);
    }

    public void DeleteBox(Box box)
    {
        FillOrClearSlots(box, false);
    }
    private void FillOrClearSlots(Box box, bool isFill)
    {
        for (int i = 0; i < box.BoxSO.slotSize; i++)
        {
            slots[GetFirstEmptySlot()] = isFill;
        }
    }
    private bool IsSlotEmpty(int slot)
    {
        if (slots[slot])
        {
            return false;
        }
        return true;
    }
    public bool TryPlaceBox(Box box)
    {
        var emptySlots = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            if (IsSlotEmpty(i))
            {
                emptySlots++;
            }
        }
        if (emptySlots >= box.BoxSO.slotSize)
        {
            emptySlots = 0;
            return true;
        }
        return false;
    }
    private int GetFirstEmptySlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (IsSlotEmpty(i))
            {
                return i;
            }
        }
        return -1;
    }
    private void ChaoticRotateBox(GameObject box)
    {
        int randomValue = Random.Range(-10, 10);
        box.transform.localEulerAngles = new Vector3(0, randomValue, 0);
    }
    private Transform GetCorrectPlacementBox(Box box)
    {
        if (box.BoxSO.slotSize == 3)
        {
            return slotsTransform[1];
        }
        if (box.BoxSO.slotSize == 2)
        {
            if (IsSlotEmpty(0))
            {
                return slotsTransform[0];
            }
            else
            {
                return slotsTransform[2];
            }

        }
        if (box.BoxSO.slotSize == 1)
        {
            return slotsTransform[GetFirstEmptySlot()];
        }
        return null;
    }
    private void ShowSlotsInfo()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Debug.Log(slots[i]);
        }
    }
   
}
