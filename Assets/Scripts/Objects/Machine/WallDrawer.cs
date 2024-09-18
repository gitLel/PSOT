using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDrawer : MonoBehaviour
{
    [SerializeField] private Transform slot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Box box))
        {
            if (box.transform.parent == null)
            {
                box.transform.SetParent(slot);
                box.transform.localPosition = Vector3.zero;
                box.transform.localScale = Vector3.one;
                box.transform.localEulerAngles = Vector3.zero;
            }

        }

    }
}
