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

        if (this.CompareTag("Canvas") && other.CompareTag("Player1"))
        {
            TakeDamage.GetComponent<Damage>().TakeDamageCanvas(other.GetComponent<PlayerController>().IsPlayerShield());
            //this.enabled = false;
            //this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject);
        }

        if (this.CompareTag("Wave") && other.CompareTag("Player1"))
        {
            TakeDamage.GetComponent<Damage>().TakeDamageWave(other.GetComponent<PlayerController>().IsPlayerShield());
        }

        if (this.CompareTag("Lightning") && other.CompareTag("Player2"))
        {
            TakeDamage.GetComponent<Damage>().TakeDamageThunder(other.GetComponent<Player2Controller>().IsPlayerShield());
        }

        if (this.CompareTag("ButtAttack") && other.CompareTag("Player2"))
        {
            TakeDamage.GetComponent<Damage>().TakeDamageGate(other.GetComponent<Player2Controller>().IsPlayerShield());
            this.transform.localScale = Vector3.zero;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
