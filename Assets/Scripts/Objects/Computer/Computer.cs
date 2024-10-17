using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.Cecil;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI time;
    [Inject] InputSystem system;
    public void Interact()
    {
        Debug.Log("comp");
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true);
       
    }
    

    private void FixedUpdate()
    {
        time.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        
    }
}
