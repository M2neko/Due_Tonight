using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    private Camera ManagedCamera;
    private float Leftmap;
    private float Rightmap;
    private float camleftrange;
    private float camrightrange;
    private float camrange;
    [SerializeField] private GameObject player1_1;
    [SerializeField] private GameObject player1_2;
    [SerializeField] private GameObject player2_1;
    [SerializeField] private GameObject player2_2;
    private GameObject Target1;
    private GameObject Target2;

    private void Awake()
    {
        if (player1_1.activeInHierarchy)
        {
            Target1 = player1_1;
        }
        else
        {
            Target1 = player1_2;
        }
        if (player2_1.activeInHierarchy)
        {
            Target2 = player1_1;
        }
        else
        {
            Target2 = player2_2;
        }
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        Leftmap = -11.0f;
        Rightmap = 11.0f;
        camrange = 6.5f;
    }

    private void LateUpdate()
    {
        var target1Position = this.Target1.transform.position;
        var target2Position = this.Target2.transform.position;
        var cameraPosition = this.ManagedCamera.transform.position;
        camleftrange = cameraPosition.x - camrange;
        camrightrange = cameraPosition.x + camrange;
        if (target1Position.x <= camleftrange)
        {
            var move = camleftrange - target1Position.x;
            cameraPosition = new Vector3(cameraPosition.x - move, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        else if (target2Position.x <= camleftrange)
        {
            var move = camleftrange - target2Position.x;
            cameraPosition = new Vector3(cameraPosition.x - move, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        else if (target1Position.x >= camrightrange)
        {
            var move = target1Position.x - camrightrange;
            cameraPosition = new Vector3(cameraPosition.x + move, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        else if (target2Position.x >= camrightrange)
        {
            var move = target2Position.x - camrightrange;
            cameraPosition = new Vector3(cameraPosition.x + move, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        if (camleftrange <= Leftmap)
        {
            cameraPosition = new Vector3(Leftmap + camrange, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        else if (camrightrange >= Rightmap)
        {
            cameraPosition = new Vector3(Rightmap - camrange, cameraPosition.y, cameraPosition.z);
            camleftrange = cameraPosition.x - camrange;
            camrightrange = cameraPosition.x + camrange;
        }

        this.ManagedCamera.transform.position = cameraPosition;
    }
}
