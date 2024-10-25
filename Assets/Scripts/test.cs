using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class test : MonoBehaviour
{
    [Inject] Shelf shelfManager;
    [Inject] StorageConfig storageConfig;

    private void Start()
    {

        //var clickStream = Observable.EveryUpdate()
        //.Where(y => Input.GetMouseButtonDown(0))
        //.Subscribe(x => Debug.Log("2"));

        var clickStreamThis = this.UpdateAsObservable()
        .Where(_ => Input.GetMouseButtonDown(1))
        .Subscribe(_ =>
        {
           
                BoxSpawner.SpawnBox(storageConfig.boxes[0].GetComponent<Box>(), transform);
            
        });
    }


}
