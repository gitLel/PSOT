using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WindowsTimeUI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI time;

    private void OnEnable()
    {
        var stream = Observable.EveryFixedUpdate()
            .Subscribe(x =>
            {
                time.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
            });
    }
}
