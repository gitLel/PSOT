using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "StorageConfig", menuName = "Configs/StorageConfig")]
public class StorageConfig : ScriptableObject
{
    public List<GameObject> boxes;

    public static int boxCount = 0;

    public static List<int> boxIDNumbers = new(0);
}
