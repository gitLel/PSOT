using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UniRx;
using UnityEngine;

public abstract class AbstractStorage : MonoBehaviour
{
    [SerializeField] public List<Transform> slots;

    public GameObject gameObj { get; set; }

    public void Place()
    {
        PlaceBox(gameObj.GetComponent<Box>());
        Debug.Log("place");
    }
    private void PlaceBox(Box box)
    {
        if (TryPlaceBox(box))
        {
            box.transform.position = GetFirstEmptyTransformSlot().position;
            box.transform.eulerAngles = Vector3.zero;
            box.transform.SetParent(GetFirstEmptyTransformSlot());

            box.gameObject.GetComponent<BoxCollider>().enabled = true;
            box.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //ChaoticRotateBox(box);

        }
    }
    private bool TryPlaceBox(Box box)
    {
        foreach (var slot in slots)
        {
            if (slot.childCount == 0)
                return true;
        }
        return false;
    }

    public Transform GetFirstEmptyTransformSlot()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)
                return slot;
        }
        return null;
    }



    //private void FillSlotsForBox(Box box, bool isFill)
    //{
    //    for (int i = 0; i < box.BoxSO.slotSize; i++)
    //    {
    //        slotsBool[GetFirstEmptyBoolSlot()] = isFill;
    //    }
    //}
    //private void FillSlots(int slotsCount, bool isTrue)
    //{
    //    for (int i = 0; i < slotsCount; i++)
    //    {
    //        slotsBool[GetFirstFullSlot()] = isTrue;
    //    }
    //}
    //private bool IsSlotEmpty(int slot)
    //{
    //    if (slotsBool[slot])
    //    {
    //        return false;
    //    }
    //    return true;
    //}


    //private int GetEmptySlots()
    //{
    //    var emptySlots = 0;

    //    for (int i = 0; i < slotsBool.Count; i++)
    //    {
    //        if (IsSlotEmpty(i))
    //        {
    //            emptySlots++;
    //        }
    //    }

    //    return emptySlots;
    //}
    //private int GetFullSlots()
    //{
    //    var fullSlots = 0;

    //    for (int i = 0; i < slotsBool.Count; i++)
    //    {
    //        if (!IsSlotEmpty(i))
    //        {
    //            fullSlots++;
    //        }
    //    }

    //    return fullSlots;
    //}

    //private int GetFirstEmptyBoolSlot()
    //{
    //    for (int i = 0; i < slotsBool.Count; i++)
    //    {
    //        if (IsSlotEmpty(i))
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}
    //private int GetFirstFullSlot()
    //{
    //    for (int i = 0; i < slotsBool.Count; i++)
    //    {
    //        if (!IsSlotEmpty(i))
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}

    //private void ChaoticRotateBox(Box box)
    //{
    //    int randomValue = Random.Range(-10, 10);
    //    box.transform.localEulerAngles = new Vector3(0, randomValue, 0);
    //}
    //private Transform GetCorrectPlacementBox(Box box)
    //{
    //    if (box.BoxSO.slotSize == 3)
    //    {
    //        return slotsTransform[1];
    //    }
    //    if (box.BoxSO.slotSize == 2)
    //    {
    //        if (IsSlotEmpty(0))
    //        {
    //            return slotsTransform[0];
    //        }
    //        else
    //        {
    //            return slotsTransform[2];
    //        }

    //    }
    //    if (box.BoxSO.slotSize == 1)
    //    {
    //        return slotsTransform[GetFirstEmptySlot()];
    //    }
    //    return null;
    //}
}
