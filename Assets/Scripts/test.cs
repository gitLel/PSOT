using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject gameObject; 
    void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(gameObject, transform);
        }
    }
}
