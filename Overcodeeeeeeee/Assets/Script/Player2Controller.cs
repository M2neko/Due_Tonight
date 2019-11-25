using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector3 Change;
    private Rigidbody2D PlayerRigidbody;
    private Animator PlayerAnimator;

    private void Start()
    {
        PlayerAnimator = this.GetComponent<Animator>();
        PlayerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Player2Jump") && this.gameObject.transform.position.y <= -3.32f) 
        {
            PlayerRigidbody.AddForce(new Vector2(0f, 5000f));
        }
        Change.x = Input.GetAxisRaw("Player2Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Change.x * Speed));
        Move();
    }

    private void Move()
    {
        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }
}