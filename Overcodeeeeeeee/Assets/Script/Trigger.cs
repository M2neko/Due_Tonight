using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Laptop") && other.CompareTag("Player1"))
        {
            TakeDamage.GetComponent<Damage>().TakeDamageLaptop(other.GetComponent<PlayerController>().IsPlayerShield());
            this.enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
