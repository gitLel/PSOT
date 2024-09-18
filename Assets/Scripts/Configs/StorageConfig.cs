using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageConfig : ScriptableObject
{
    public static string visitorName;
    public static int boxCount = 0;
    public static int currentBoxNumber;

    public static List<int> boxIDNumbers = new();
}
