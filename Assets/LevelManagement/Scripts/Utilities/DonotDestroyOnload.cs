using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroyOnload : MonoBehaviour
{
    private void Awake()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }
}
