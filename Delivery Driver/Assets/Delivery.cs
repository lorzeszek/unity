using System.Drawing;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,0,0,1);
    [SerializeField] float destroyDelay = 1f;

    bool packagePickedUp;

    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You hit object: " + other.collider.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Customer" && packagePickedUp)
        {
            Debug.Log("Package Delivered to Customer!");
            
            packagePickedUp = false;

            _spriteRenderer.color = noPackageColor;
        }

        if (other.tag == "Package" && !packagePickedUp)
        {
            Debug.Log("Package Collected!");

            packagePickedUp = true;
            _spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
        }
    }



    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Package") 
    //    {
    //        Debug.Log("Package Collected!");
    //    }

    //    if (other.tag == "Customer")
    //    {
    //        Debug.Log("Package Delivered to Customer!");
    //    }
    //}
}
