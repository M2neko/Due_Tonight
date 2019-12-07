using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Playground;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject player1_1;
    [SerializeField] private GameObject player1_2;
    [SerializeField] private GameObject player2_1;
    [SerializeField] private GameObject player2_2;
    private float xrange;
    private float leftrange;
    private float rightrange;
    private GameObject player2;
    private Vector3 Change;
    private Rigidbody2D PlayerRigidbody;
    private Animator PlayerAnimator;

    private void Start()
    {
        xrange = Playground.GetComponent<BoxCollider2D>().size.x * 15;
        leftrange = Playground.transform.position.x - xrange;
        rightrange = Playground.transform.position.x + xrange;
        if (player2_1.activeInHierarchy)
        {
            player2 = player2_1;
        }
        else
        {
            player2 = player2_2;
        }
        PlayerAnimator = this.GetComponent<Animator>();
        PlayerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (player1_1.activeInHierarchy)
            {
                this.GetComponent<ShootGate>().Shoot();
            }
            if (player1_2.activeInHierarchy)
            {
                this.GetComponent<ShootCanvas>().Shoot();
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (player1_1.activeInHierarchy)
            {
                this.GetComponent<NovaGates>().Nova();
            }
            if (player1_2.activeInHierarchy)
            {
                //this.GetComponent<NovaGates>().Nova();
            }
        }
        var targetposition = this.gameObject.transform.position;
        if (this.gameObject.transform.position.x >= player2.transform.position.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetButtonDown("Player1Jump") && this.gameObject.transform.position.y <= -3.32f)
        {
            PlayerRigidbody.AddForce(Vector2.up * 3000);
        }
        Change.x = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Change.x * Speed));
        Move();
        if (this.gameObject.transform.position.x <= leftrange)
        {
            targetposition = new Vector3(leftrange, targetposition.y, targetposition.z);
        }
        if (this.gameObject.transform.position.x >= rightrange)
        {
            targetposition = new Vector3(rightrange, targetposition.y, targetposition.z);
        }
        this.gameObject.transform.position = targetposition;
        if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<Light>().Pi(player2);
        }
    }

    public GameObject OtherPlayer()
    {
        return player2;
    }

    private void Move()
    {
        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }
}
