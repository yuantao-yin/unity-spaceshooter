using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float tilt;
    public Boundary boundary;
    Rigidbody rigidbody;

    public GameObject shot;
    public GameObject shotSpawn;
    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;

    public FixedJoystick fixedJoystick;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireDelta;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rigidbody.velocity = direction * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
