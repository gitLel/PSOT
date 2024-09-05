using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Box : MonoBehaviour, IInteractable, ITakeable
{

    public void Interact()
    {
        Debug.Log("Korobka has been interacted");
    }

}
