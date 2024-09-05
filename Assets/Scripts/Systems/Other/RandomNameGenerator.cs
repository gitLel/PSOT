using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RandomNameGenerator
{
    private static string maleNames = "Assets/TextData/MaleNames.txt";
    private static string maleSurnames = "Assets/TextData/MaleSurnames.txt";

    //private static string femaleNames = "Assets/TextData/FemaleNames.txt";
    //private static string femaleSurnames = "Assets/TextData/FemaleSurnames.txt";

    TextAsset maleNamesData = AssetDatabase.LoadAssetAtPath<TextAsset>(maleNames);
    TextAsset maleSurnamesData = AssetDatabase.LoadAssetAtPath<TextAsset>(maleSurnames);



    public string GetMaleName()
    {
        string[] maleNames = maleNamesData.text.Split('\n');

        string maleFullName = maleNames[Random.Range(0, maleNames.Length - 1)];

        return maleFullName;
    }
    public string GetMaleSurname()
    {
        string[] maleSurnames = maleSurnamesData.text.Split('\n');

        string maleFullName = maleSurnames[Random.Range(0, maleNames.Length - 1)];

        return maleFullName;
    }


}
