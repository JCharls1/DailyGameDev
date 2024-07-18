using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Basic Movement")]
    [SerializeField] private float speed; 
    [SerializeField] float jump = 101;
    [SerializeField] float gravity; 
    [SerializeField] float fallGravity;
    [SerializeField] float buttonPressWindow;
    float buttonPressedTim;
    bool jumping;
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    private bool isGrouded;
    private bool isFacingRight = true;

    [Header("Dashing")]
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private static bool canDash = true;
    private bool isDashing;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrouded){
            rb.gravityScale = gravity;
            float jumpForce = Mathf.Sqrt(jump * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            buttonPressedTim = 0;
            isGrouded = false;
        }

        // determine the height of the jump depending on how fast the jump button is pressed
        if(jumping){
            buttonPressedTim += Time.deltaTime;
            if(buttonPressedTim < buttonPressWindow && Input.GetKeyUp(KeyCode.Space)){
                rb.gravityScale = fallGravity;
            }

            if(rb.velocity.y < 0){
                rb.gravityScale = fallGravity;
                jumping = false;
            }
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate(){
        if (isDashing){
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            isGrouded = true;
            canDash = true;
            Debug.Log("82");
        }
        
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash(){
        canDash = false;
        Debug.Log("100");
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        isGrouded = false;
        Vector2 dashDirection = new Vector2(horizontal, vertical).normalized;
        rb.velocity = dashDirection * dashingPower;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        if(isGrouded){
            canDash = true;
            Debug.Log("110");
        }
    }

    public static void setCanDash(bool dash){
        canDash = dash;
    }
}
