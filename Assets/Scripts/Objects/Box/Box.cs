using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Box : MonoBehaviour, IInteractable, ITakeable
{

    [field:SerializeField] public BoxSO BoxSO {  get; private set; }
    public int boxNumberID;


    public void Interact()
    {
        Debug.Log("Эта коробка: " + boxNumberID + "\n");
    }

}
