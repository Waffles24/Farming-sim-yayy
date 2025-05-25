using UnityEngine;

public class Movement : MonoBehaviour
{
    /*serialize Field makes the variable visible to the inspector without being public and 
     accessible to other scripts*/
     
    [SerializeField] private float Speed;
    [SerializeField] private Animator animator;


    private void Update()
    {
       //update is called very often so input should be taken from here

       /* GetAxisRaw will return values of either -1, 0 or 1;
        unlike GetAxis which has more smoothing 
       I tried both, but GetAxisRaw seems to work better for pixel art - 
       possibly due to the smoothing effect, GetAxis made the character look more "wobbly" when moving.
        */
              
       float Horizontal = Input.GetAxisRaw("Horizontal");
       float Vertical   = Input.GetAxisRaw("Vertical");

        // transform.position requires a vector 3 rather than 2
        Vector3 Direction = new Vector3(Horizontal, Vertical);

        AnimateMovement(Direction);

        /* "=" assigns the value on the right to the variable on the left.
          "+=" adds the value on the right to the variable on the left, aswell as replacing it.
         
        E.g. where variable A = 2
        A = 1 
        will change the original value from 2 to 1. 

        A += 1
        will add 1 to the value of A : 1 + 2 = 3, so A would now be 3.*/

       /* Time.deltaTime is really important for smoothing! Even with GetAxis, it's still jumpy.
         with GetAxis the character seemed to keep moving after the key was let go - this could work
        for an icy level, although for grass I want a faster response.
        */
        transform.position += Direction * Speed * Time.deltaTime;

    }

    void AnimateMovement(Vector3 Direction)
    {
        if (animator != null)
        {
            if (Direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("Horizontal", Direction.x);
                animator.SetFloat("Vertical", Direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }





}