using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickAim : MonoBehaviour
{
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gunDirection = Vector3.left * -Input.GetAxis("HorizontalRStick") + Vector3.up * Input.GetAxis("VerticalRStick");

        if(gunDirection.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(gunDirection, Vector3.up);

            if(player.canFire)
            {
                player.StartCoroutine("Shoot");

            }

        }
    }
}
