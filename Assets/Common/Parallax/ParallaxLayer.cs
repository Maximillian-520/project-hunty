using UnityEngine;

// [ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    // [Header("Parallax Settings")]
    // [Tooltip("How much this layer moves relative to the camera (0 = no movement, 1 = same as camera)")]
    public float parallaxFactor = 1.0f;
    // [Header("Infinite Scrolling (Optional)")]
    public bool infiniteScrolling = false;
    public float spriteWidth = 20f;   // Width of the sprite for looping

    private float startPosX;

    void Start()
    {
        startPosX = transform.localPosition.x;
    }

    public void Move(float delta, Vector3 camPosition)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        // newPos.y -= delta * parallaxFactor;
 
        transform.localPosition = newPos;

        // Optional infinite scrolling
        if (infiniteScrolling)
        {
            float distance = (transform.localPosition.x - startPosX) * (1 - parallaxFactor);
            // float temp = camPosition.x * parallaxFactor;

            if (distance > startPosX + spriteWidth)
                startPosX -= spriteWidth;
            else if (distance < startPosX - spriteWidth)
                startPosX += spriteWidth;
        }
    }




    // private Transform cam;
    // private Vector3 lastCamPosition;
    // private float startPosX;

    // void Start()
    // {
    //     cam = Camera.main.transform;
    //     lastCamPosition = cam.position;
    //     startPosX = transform.position.x;
    // }

    // void LateUpdate()
    // {
    //     Vector3 deltaMovement = cam.position - lastCamPosition;

    //     // Move layer based on camera movement
    //     transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);

    //     lastCamPosition = cam.position;

    //     // Optional infinite scrolling
    //     if (infiniteScrolling)
    //     {
    //         float distance = cam.position.x * (1 - parallaxFactor);
    //         float temp = cam.position.x * parallaxFactor;

    //         if (distance > startPosX + spriteWidth)
    //             startPosX += spriteWidth;
    //         else if (distance < startPosX - spriteWidth)
    //             startPosX -= spriteWidth;
    //     }
    // }
}
