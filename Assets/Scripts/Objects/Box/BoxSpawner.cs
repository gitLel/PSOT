using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public static void SpawnBox(Box box, Transform spot)
    {
        var boxPrefab = Instantiate(box.gameObject, spot);
        boxPrefab.transform.position = spot.position;
        SetIdForBox(boxPrefab);
    }

    private static void SetIdForBox(GameObject boxPrefab)
    {
        var id = Random.Range(1000, 9999);
        boxPrefab.GetComponent<Box>().BoxID = id;

        StorageConfig.boxIDNumbers.Add(boxPrefab.GetComponent<Box>().BoxID);
    }
}
