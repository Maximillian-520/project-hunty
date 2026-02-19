using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float radius = 0.1f;
    [SerializeField] private string groundTag = "Ground";

    public bool isOnGround {private set; get;}

    void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius);
        if(!collider) isOnGround = false;
        else{isOnGround = collider.gameObject.CompareTag(groundTag);}
    }
}
