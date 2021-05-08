using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float forwardSpeed = 10.0f;

    [SerializeField]
    public float strafaSpeed = 10.0f;

    [SerializeField]
    public float LiftForce = 10.0f;

    [SerializeField]
    private float activeforwardSpeed = 10.0f;

    [SerializeField]
    private float activeStrefaSpeed = 10.0f;

    [SerializeField]
    private float activeHoverSpeed = 10.0f;

    [SerializeField]
    public float forwardAcceleration = 2.0f;

    [SerializeField]
    public float strefaAcceleration = 2.0f;

    [SerializeField]
    public float LiftAcceleration = 2.0f;

    [SerializeField]
    public Text timeCounter;
    public float startTime;

    public float shootForce = 5000f;


    public float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    //Parametry do upgradu

    public int maxHealth = 10;

    [SerializeField]
    private int currentHealth;

    public delegate void HealthUpdated();

    public HealthUpdated healthUpdated;

    public GameObject projectile;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        startTime = Time.time;

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }

    public void UpdateHealth(int val)
    {
        currentHealth -= val;
        if (healthUpdated != null) healthUpdated();
    }

    private void TakeDamage(int damage)
    {
        Debug.Log("Damage taken: " + damage);
        UpdateHealth(-damage);
    }

    private void Shoot()
    {
        var projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = transform.position + Vector3.down * 3;
        projectileInstance.transform.rotation = transform.rotation;
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * shootForce);
        projectileInstance.GetComponent<Projectile>();
    }

    public string currentTime()
    {
        return timeCounter.text; 
    }

    private void TimeControll()
    {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timeCounter.text = minutes + ":" + seconds;
    }

    // Update is called once per frame

    public void KnockBack()
    {
        rb.AddRelativeForce(Vector3.back * 1000f);
    }

    private void Update()
    {
        TimeControll();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(20);
        }
        if (Input.GetButtonDown("Shot"))
        {
            Shoot();
        }

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);
        rollInput = 0;
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeforwardSpeed = Mathf.Lerp(activeforwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrefaSpeed = Mathf.Lerp(activeStrefaSpeed, Input.GetAxisRaw("Horizontal") * strafaSpeed, strefaAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeStrefaSpeed, Input.GetAxisRaw("Hover") * LiftForce, LiftAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrefaSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mine")
        {
            TakeDamage(10);
        }
        if (other.tag == "EnemyMissile")
        {
        }
        KnockBack();
    }
}