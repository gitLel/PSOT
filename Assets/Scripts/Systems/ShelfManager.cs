using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private List<Transform> slotsTransform;

    [SerializeField] private List<GameObject> debugSlotsVisual;

    [SerializeField] private List<bool> slots;
    
    public void PlaceBox(BoxSO box)
    {
        if (TryPlaceBox(box))
        {

            var vbox = Instantiate(box.boxPrefab, this.transform);
            vbox.transform.position = GetCorrectPlacementBox(box).position;

            ChaoticRotateBox(vbox);

            FillSlotsForBox(box);
        }

    }
    private void FillSlotsForBox(BoxSO box)
    {
        for (int i = 0; i < box.slotSize; i++)
        {
            slots[GetFirstEmptySlot()] = true;
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
    public bool TryPlaceBox(BoxSO box)
    {
        var emptySlots = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            if (IsSlotEmpty(i))
            {
                emptySlots++;
            }
        }
        if (emptySlots >= box.slotSize)
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
    private Transform GetCorrectPlacementBox(BoxSO boxPrefab)
    {
        if (boxPrefab.slotSize == 3)
        {
            return slotsTransform[1];
        }
        if (boxPrefab.slotSize == 2)
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
        if (boxPrefab.slotSize == 1)
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
    private void HideSlotsVisual()
    {
        foreach (var slot in debugSlotsVisual)
        {
            slot.SetActive(false);
        }

    }
}
