using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleStorageService : MonoBehaviour
{
    private IStorageService storageService;
    private const string key = "example_key";
    private void Start()
    {
        storageService = new JsonToFileStorageService();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            ExampleStorageItem e = new ExampleStorageItem();
            e.StringParameter = "example";

            storageService.Save(key, e);
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            storageService.Load<ExampleStorageItem>(key, e => {  } );
        }
    }
    public class ExampleStorageItem
    {
        public string StringParameter { get; set; }

    }
}
