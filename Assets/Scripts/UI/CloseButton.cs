using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseWindow);
    }
    
    private void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
