using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,Random.Range(2,5));
    }
}
