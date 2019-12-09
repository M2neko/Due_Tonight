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
    [SerializeField] private GameObject Welcome_Slogan;
    [SerializeField] private GameObject TakeDamage;
    [SerializeField] private bool IsStart = true;
    private float xrange;
    private float leftrange;
    private float rightrange;
    private GameObject player2;
    private Vector3 Change;
    private Rigidbody2D PlayerRigidbody;
    private Animator PlayerAnimator;
    private bool IsDown = false;
    private bool IsShield = false;
    private bool IsMotivate = false;
    private bool IsDead = false;

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
        StartCoroutine(StartAnimator());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Player1Skill2") && !IsHold())
        {
            if (player1_1.activeInHierarchy)
            {
                this.GetComponent<ShootGate>().Shoot();
            }
            if (player1_2.activeInHierarchy)
            {
                this.GetComponent<Light>().Pi(player2);
            }
        }
        if (Input.GetButtonDown("Player1Skill3") && !IsHold())
        {
            if (player1_1.activeInHierarchy)
            {
                this.GetComponent<NovaGates>().Nova();
            }
        }
        if (Input.GetButton("Player1Shield") && ((!IsHold()) || IsShield))
        {
            PlayerAnimator.SetBool("Shield", true);
            IsShield = true;
        }
        else
        {
            PlayerAnimator.SetBool("Shield", false);
            IsShield = false;
        }
        if (Input.GetButtonDown("Player1Skill1") && !IsHold())
        {
            if (player1_1.activeInHierarchy)
            {
                this.GetComponent<RushBike>().Rush();
            }
            if (player1_2.activeInHierarchy && this.gameObject.transform.position.y <= -3.32f)
            {
                this.GetComponent<SpeedPunch>().Punch();
            }
        }
        var targetposition = this.gameObject.transform.position;
        if (this.gameObject.transform.position.x >= player2.transform.position.x)
        {
            if ((!IsHold()) || IsShield)
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if ((!IsHold()) || IsShield)
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetButtonDown("Player1Jump") && this.gameObject.transform.position.y <= -3.32f && !IsHold())
        {
            PlayerRigidbody.AddForce(Vector2.up * 3000);
        }
        if (Input.GetButton("Player1Down") && ((!IsHold()) || IsDown))
        {
            PlayerAnimator.SetBool("Down", true);
            IsDown = true;
        }
        else
        {
            PlayerAnimator.SetBool("Down", false);
            IsDown = false;
        }

        Change.x = Input.GetAxisRaw("Horizontal");

        if (IsMotivate && !IsHold())
        {
            IsMotivate = false;
        }

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

        if (TakeDamage.GetComponent<Damage>().IsPlayer1Dead())
        {
            PlayerAnimator.SetBool("Dead", true);
            EndGame.IsEnd = true;
            IsDead = true;
        }

        if (TakeDamage.GetComponent<Damage>().IsPlayer2Dead())
        {
            PlayerAnimator.SetFloat("Speed", 0.0f);
        }
    }

    public float GetLeft()
    {
        return leftrange;
    }

    public float GetRight()
    {
        return rightrange;
    }

    public GameObject OtherPlayer()
    {
        return player2;
    }

    private void Move()
    {
        if (IsHold())
            return;

        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }

    private bool IsHold()
    {
        return RushBike.IsRush || Light.IsLight || this.IsDown || this.IsStart
            || SpeedPunch.IsPunch || this.IsShield || EndGame.IsEnd
            || EndGame.IsExpired;
    }

    public bool IsPlayerShield() => IsShield;

    public bool IsPlayerDead() => IsDead;

    private IEnumerator StartAnimator()
    {
        yield return new WaitForSeconds(0.2f);
        if (player1_2.activeInHierarchy)
            this.Welcome_Slogan.SetActive(true);

        yield return new WaitForSeconds(2.8f);
        this.GetComponent<Animator>().SetBool("Start", false);
        if (player1_2.activeInHierarchy)
            this.Welcome_Slogan.SetActive(false);
        this.IsStart = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("1 is attacked");

        var IsDefense = player2.GetComponent<Player2Controller>().IsPlayerShield();

        if (other.collider.CompareTag("Player2"))
        {
            if (RushBike.IsRush && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamageRush(IsDefense);
                IsMotivate = true;
            }

            if (SpeedPunch.IsPunch && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamagePunch(IsDefense);
                IsMotivate = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        //Debug.Log("1 is staying");

        var IsDefense = player2.GetComponent<Player2Controller>().IsPlayerShield();

        if (other.collider.CompareTag("Player2"))
        {
            if (RushBike.IsRush && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamageRush(IsDefense);
                IsMotivate = true;
            }

            if (SpeedPunch.IsPunch && !IsMotivate)
            {
                TakeDamage.GetComponent<Damage>().TakeDamagePunch(IsDefense);
                IsMotivate = true;
            }
        }
    }
}
