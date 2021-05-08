using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform RocketTarget;

    private Rigidbody rb;

    public float turnSpeed = 1f;
    public float rocketFlySpeed = 10f;

    private void Start()
    {
        RocketTarget = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * rocketFlySpeed;

        var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - transform.position);

        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRot, turnSpeed));
    }

    private void OnDestroy()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayersProjectile"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //DestroyObj();
        }
    }
}