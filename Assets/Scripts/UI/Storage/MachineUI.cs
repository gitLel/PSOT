using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MachineUI : MonoBehaviour
{
    [SerializeField] private Image imageCheck;

    

    private void Start()
    {
        imageCheck.color = Color.gray;
    }
    public void SetColorForScreen(bool isCurrect)
    {
        if (isCurrect)
            imageCheck.color = Color.blue;
        else
            imageCheck.color = Color.red;
    }
    private void Update()
    {
        if (Machine.boxSlot != null)
        {
            if (StorageConfig.boxNumber == Machine.boxSlot.boxNumberID)
            {
                SetColorForScreen(true);

                Debug.Log("Вы нашли коробку)");
            }
            else
            {
                SetColorForScreen(false);
                Debug.Log("Это не та коробка(");
            }
        }
    }
}
