using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player2Controller>().SetFreeze(true);

    }
}