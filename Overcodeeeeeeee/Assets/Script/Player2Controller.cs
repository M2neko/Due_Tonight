using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private GameObject Playground;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject player2_1;
    [SerializeField] private GameObject player2_2;
    [SerializeField] private GameObject player1_1;
    [SerializeField] private GameObject player1_2;
    private float xrange;
    private float leftrange;
    private float rightrange;
    private GameObject player1;
    private Vector3 Change;
    private Rigidbody2D PlayerRigidbody;
    private Animator PlayerAnimator;
    private bool IsDown = false;

    private void Start()
    {
        xrange = Playground.GetComponent<BoxCollider2D>().size.x * 15;
        leftrange = Playground.transform.position.x - xrange;
        rightrange = Playground.transform.position.x + xrange;
        if (player1_1.activeInHierarchy)
        {
            player1 = player1_1;
        }
        else
        {
            player1 = player1_2;
        }
        PlayerAnimator = this.GetComponent<Animator>();
        PlayerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player2_1.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire3") && !IsHold())
            {
                this.GetComponent<ShootLaptop>().Shoot();
                PlayerAnimator.SetBool("1", true);
            }
        }
        var targetposition = this.gameObject.transform.position;
        if (this.gameObject.transform.position.x >= player1.transform.position.x)
        {
            if (!IsHold())
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (!IsHold())
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetButtonDown("Player2Jump") && this.gameObject.transform.position.y <= -3.32f && !IsHold()) 
        {
            PlayerRigidbody.AddForce(Vector2.up * 3000);
        }
        if (Input.GetButton("Player2Down"))
        {
            PlayerAnimator.SetBool("Down", true);
            IsDown = true;
        }
        else
        {
            PlayerAnimator.SetBool("Down", false);
            IsDown = false;
        }
        Change.x = Input.GetAxisRaw("Player2Horizontal");

        if (!IsHold())
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
    }

    public GameObject OtherPlayer()
    {
        return player1;
    }

    private void Move()
    {
        if (IsHold())
            return;

        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }

    private bool IsHold()
    {
        return this.IsDown;
    }
}