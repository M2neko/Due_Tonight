using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGhost : MonoBehaviour
{
    [SerializeField] private GameObject TakeDamage;

    [SerializeField] private GameObject Character1_1;
    [SerializeField] private GameObject Character1_2;
    [SerializeField] private GameObject Character2_1;
    [SerializeField] private GameObject Character2_2;

    private GameObject Player1;
    private GameObject Player2;

    private void Update()
    {
        Player1 = Character1_1.activeInHierarchy ? Character1_1 : Character1_2;
        Player2 = Character2_1.activeInHierarchy ? Character2_1 : Character2_2;

        if (EndGame.IsEnd)
        {
            if (TakeDamage.GetComponent<Damage>().IsPlayer1Dead())
            {
                this.transform.position = Player1.transform.position + Vector3.up;
                if (Player1.transform.position.x < Player2.transform.position.x)
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                else
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (TakeDamage.GetComponent<Damage>().IsPlayer2Dead())
            {
                this.transform.position = Player2.transform.position + Vector3.up;
                if (Player2.transform.position.x < Player1.transform.position.x)
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                else
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
