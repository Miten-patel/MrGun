using UnityEngine;

public class test : MonoBehaviour
{
    public float climbSpeed = 2f; 

    private bool isClimbing = false; 

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ladder"))
    //    {
    //        isClimbing = true;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ladder"))
    //    {
    //        isClimbing = false;
    //    }
    //}

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            Debug.Log("climbing");
            float verticalInput = Input.GetAxis("Vertical");

          
            Vector2 climbVelocity = new Vector2(0f, verticalInput * climbSpeed);

           
            GetComponent<Rigidbody2D>().velocity = climbVelocity;
        }
    }
}