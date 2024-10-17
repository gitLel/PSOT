using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Box : MonoBehaviour, IInteractable, ITakeable
{

    [field:SerializeField] public BoxSO BoxSO {  get; private set; }

    public int BoxID { get; set; }


    public void Interact()
    {
        Debug.Log("Эта коробка: " + BoxID + "\n");
    }

}
