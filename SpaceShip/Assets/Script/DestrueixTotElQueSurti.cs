using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrueixToElQueSurti : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
