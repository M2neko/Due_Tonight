using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        Change.x = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Change.x * Speed));
        Move();
    }

    private void Move()
    {
        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }
}
