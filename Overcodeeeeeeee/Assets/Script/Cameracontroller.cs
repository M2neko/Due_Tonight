using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    private Camera ManagedCamera;
    private float distance;
    [SerializeField] private GameObject player1_1;
    [SerializeField] private GameObject player1_2;
    private GameObject Target1;

    private void Awake()
    {
        if (player1_1.activeInHierarchy)
        {
            Target1 = player1_1;
        }
        if (player1_2.activeInHierarchy)
        {
            Target1 = player1_2;
        }
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        distance = Mathf.Abs(Target1.transform.position.x - Target1.GetComponent<PlayerController>().OtherPlayer().transform.position.x);
        var rate = distance / 9.21f;
        var view = rate * 50;
        if (view <= 50)
        {
            view = 50;
        }
        if (view >= 70)
        {
            view = 70;
        }
        ManagedCamera.fieldOfView = view;
    }
}
