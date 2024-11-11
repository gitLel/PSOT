using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject window;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => window.SetActive(IsActiveWindow()));
    }
    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(() => window.SetActive(IsActiveWindow()));

    }
    private bool IsActiveWindow()
    {
        bool flag = true;

        if (flag)
        {
            flag = !flag;
            return true;
        }
        else
        {
            flag = !flag;
            return false;
        }
    }
}
