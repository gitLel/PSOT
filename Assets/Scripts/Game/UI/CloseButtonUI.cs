using UnityEngine;
using UnityEngine.UI;

public sealed class CloseButtonUI : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(CloseWindow);
    }
    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(CloseWindow);

    }
    private void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
