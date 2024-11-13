using UnityEditor;
using UnityEngine;

public class RandomNameGenerator
{
    //private string maleNames = "Assets/TextData/MaleNames.txt";
    //private string maleSurnames = "Assets/TextData/MaleSurnames.txt";

    //private string femaleNames = "Assets/TextData/FemaleNames.txt";
    //private string femaleSurnames = "Assets/TextData/FemaleSurnames.txt";

    private TextAsset maleNamesData = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/TextData/MaleNames.txt");
    private TextAsset maleSurnamesData = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/TextData/MaleSurnames.txt");

    private TextAsset femaleNamesData = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/TextData/FemaleNames.txt");
    private TextAsset femaleSurnamesData = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/TextData/FemaleSurnames.txt");

    public string GetName(bool isMale)
    {
        if (isMale)
        {
            string[] maleNames = maleNamesData.text.Split('\n');
            string[] maleSurnames = maleSurnamesData.text.Split('\n');

            string fullMaleName = maleNames[Random.Range(0, maleNames.Length - 1)] + " " + maleSurnames[Random.Range(0, maleSurnames.Length - 1)];
            return fullMaleName;

        }
        else
        {
            string[] femaleNames = femaleNamesData.text.Split('\n');
            string[] femaleSurnames = femaleSurnamesData.text.Split('\n');

            string femaleFullName = femaleNames[Random.Range(0, femaleNames.Length - 1)] + "\n" + femaleSurnames[Random.Range(0, femaleSurnames.Length - 1)];
            return femaleFullName;
        }
    }
}
