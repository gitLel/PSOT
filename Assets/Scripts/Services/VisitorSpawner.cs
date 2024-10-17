using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class VisitorSpawner : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject visitorPrefab;
    [SerializeField] private Transform visitorSpawnPoint;

    public void Spawn()
    {
        var visitor = Instantiate(visitorPrefab);
        visitor.transform.SetParent(visitorSpawnPoint, false);
        visitor.transform.localPosition = Vector3.zero;
    }

}
