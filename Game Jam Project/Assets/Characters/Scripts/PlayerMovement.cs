using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashForce;

    [SerializeField] private Rigidbody2D rb; 

    [SerializeField] private Vector3 movement; 

    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        moveSpeed = 2.5f;
        dashForce = 500f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        Move();
        SetRoatation();
    }

    public void SetRoatation()
    {
        if (Input.GetAxisRaw("Horizontal") < 0) sr.flipX = true;
        else if (Input.GetAxisRaw("Horizontal") > 0) sr.flipX = false;
    }

	private void Move()
	{
        // Получаем входы от пользователя
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Создаем вектор перемещения на основе входов
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f)  * moveSpeed * Time.deltaTime;

        // Применяем перемещение к объекту с помощью метода Translate
        transform.Translate(movement);
    }

    public void Dash()
    {
        // Получаем входы от пользователя
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

         Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;
		if (horizontalInput == 0 && verticalInput == 0)
		{
            if (sr.flipX)
                rb.AddForce(Vector2.left * dashForce);
            else if(!sr.flipX)
                rb.AddForce(Vector2.right * dashForce);
        }
        else rb.AddForce(movementDirection * dashForce);

    }

    public void StopMove() => rb.velocity = Vector2.zero;

}
