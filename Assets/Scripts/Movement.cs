using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
       float Horizontal = Input.GetAxisRaw("Horizontal");
       float Vertical   = Input.GetAxisRaw("Vertical");

    }






}