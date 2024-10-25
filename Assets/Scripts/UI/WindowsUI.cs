using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WindowsUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button controlPanelButton;
    [SerializeField] private Button guidePanelButton;
    [SerializeField] private Button boxInfoButton;

    [Header("Panels")]
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject boxInfoPanel;

    [Header("Other")]
    [SerializeField] private TextMeshProUGUI time;


    private void Start()
    {
        var stream = Observable.EveryFixedUpdate()
            .Subscribe(x =>
            {
                time.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
            });
        controlPanelButton.onClick.AddListener(ShowControlPanel);
        guidePanelButton.onClick.AddListener(ShowGuidePanel);
        boxInfoButton.onClick.AddListener(ShowBoxInfoPanel);
    }

    private void ShowControlPanel()
    {
        controlPanel.SetActive(true);
    }
    private void ShowGuidePanel()
    {
        guidePanel.SetActive(true);
    }
    private void ShowBoxInfoPanel()
    {
        boxInfoPanel.SetActive(true);
    }

    private void StartAccommoditation()
    {

    }
}
