using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float speedBoosted = 45f;
    [SerializeField] float speedDefualt = 30f;
    [SerializeField] float speedDecrease = 10f;
    private Rigidbody2D rb2D;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            PlayerRotate();
            PlayerBoost();
        }

    }

    public void DisableConstrolers()
    {
        canMove = false;
    }

    public void AnableControlers()
    {
        canMove = true;
    }

    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }

    private void PlayerBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = speedBoosted;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = speedDecrease;
        }
        else
        {
            surfaceEffector2D.speed = speedDefualt;
        }
    }
}
