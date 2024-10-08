using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class BoxInfoUI : MonoBehaviour
{
    [Inject]
    private RandomNameGenerator randomNameGenerator;
    [Inject]
    private RandomNumberGenerator randomNumberGenerator;

    [SerializeField] private TextMeshProUGUI visitorName;
    [SerializeField] private TextMeshProUGUI boxNumber;
    [SerializeField] private TextMeshProUGUI boxCount;

    private void Start()
    {
        boxNumber.text = "Box number: " + StorageConfig.currentBoxNumber;
        visitorName.text = $"{randomNameGenerator.GetMaleName()}";
    }
    private void Update()
    {
        boxCount.text = "Box count: " + StorageConfig.boxCount.ToString();

    }
    


}
