using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float slowSpeed = 15f;
    [SerializeField] private float boostSpeed = 30f;


    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Package"))
        {
            moveSpeed = slowSpeed;

            Debug.Log("Slowed down! " + moveSpeed);

        }
        //if (other.collider.CompareTag("Package"))
        //{
        //    moveSpeed = boostSpeed;
        //    Debug.Log("Boosted! " + moveSpeed);
        //}

        ////if (other.collider.name.Contains("Package"))
        ////{
        ////    moveSpeed = boostSpeed;
        ////}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boosted! " + moveSpeed);
        }
    }

    void Update()
    {
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
        
    }
}
