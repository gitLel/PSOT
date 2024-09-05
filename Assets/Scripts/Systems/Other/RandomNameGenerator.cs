using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RandomNameGenerator
{
    private static string filePath = "Assets/TextData/Names.txt";

    TextAsset namesData = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);


    public string GetName()
    {

        string[] lines = namesData.text.Split('\n');

        string name = lines[Random.Range(0, lines.Length - 1)];

        return name;
    }


}
