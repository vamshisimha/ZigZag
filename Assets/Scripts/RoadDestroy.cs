using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
