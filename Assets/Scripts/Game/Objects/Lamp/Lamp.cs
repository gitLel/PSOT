using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> lamps;

    private bool isEnable = true;
    private void Start()
    {
        foreach (var lamp in lamps)
        {
            lamp.SetActive(false);
        }
    }
    public void Interact()
    {
       StartCoroutine(InteractLamps());
       Debug.Log("s");
    }
    private IEnumerator InteractLamps()
    {
        foreach (var lamp in lamps)
        {
            lamp.SetActive(isEnable);
            yield return new WaitForSeconds(1);
        }
        isEnable = !isEnable;
    }
}
