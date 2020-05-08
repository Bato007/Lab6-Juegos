using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject prefab;
    private GameObject newObj;

    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        newObj = Instantiate(prefab, startPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && !newObj)
        {
            newObj = Instantiate(prefab, startPosition, Quaternion.identity);
        }
    }
}
