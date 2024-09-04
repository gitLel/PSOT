using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Box", menuName = "Objects/Box")]
public class BoxSO : ScriptableObject
{
    public GameObject boxPrefab;
    public int slotSize;
}
