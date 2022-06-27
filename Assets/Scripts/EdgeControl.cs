using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeControl : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }
}