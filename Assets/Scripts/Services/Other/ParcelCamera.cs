using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParcelCamera : MonoBehaviour
{
    [SerializeField] private Transform parcelTransform;
    private Box parcelPrefab;

    public void PlaceParcelOnCamera(Box parcelPrefab)
    {
        this.parcelPrefab = parcelPrefab;
        parcelPrefab = Instantiate(parcelPrefab, transform);
        parcelPrefab.transform.position = parcelTransform.position;

        parcelPrefab.GetComponent<Rigidbody>().isKinematic = true; 

        parcelPrefab.transform.localEulerAngles = new Vector3(35, 0, 0);

    }
    

}
