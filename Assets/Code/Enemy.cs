using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float amplitud = 3, velocidad = 2;
    Vector3 inicial;

    // Start is called before the first frame update
    void Start()
    {
        inicial = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = inicial + new Vector3(0, amplitud * Mathf.Sin(Time.time * velocidad), 0);
    }
}
