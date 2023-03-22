using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool twinstick = false;
    public bool mouseaim = false;
    public bool classic = false;

    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    


    [Header ("Shooting")]
    public GameObject bullet;
    public GameObject gun;
    public float fireRate = 0.5f;
    public bool canFire = true;
   

    // Start is called before the first frame update
    void Start()
    {
        if(twinstick)
        {
            gun.GetComponent<TwinStickAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;

        }
        else 
        {
            gun.GetComponent<TwinStickAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        //print(hor);
        //print(ver);

        //This is for moving the player
           //transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, ver * playerSpeed * Time.deltaTime, 0));

       transform.Translate(Vector3.right*playerSpeed*Time.deltaTime*hor);
       transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime * ver);



        //This is for shooting

        if (!twinstick && Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
