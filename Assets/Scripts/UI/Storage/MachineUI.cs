using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MachineUI : MonoBehaviour
{
    
    private void Update()
    {
        if (Machine.boxSlot != null)
        {
            if (StorageConfig.currentBoxNumber == Machine.boxSlot.boxNumberID)
            {
                
                Debug.Log("�� ����� �������)");
            }
            else
            {
              
                Debug.Log("��� �� �� �������(");
            }
        }
    }
}
