using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballSerializedField;
    [SerializeField] SpringJoint2D springJointField;
    [SerializeField] float DetachDelay;

    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ballSerializedField == null)
        {
            return;
        }

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {

            if (isDragging) 
            {
                LaunchBall();
            }

            isDragging = false;

            return;
        }

        isDragging = true;

        ballSerializedField.isKinematic = true;

        Vector2 touchPositionScreenSpace = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 touchPositionWorldSpace = Camera.main.ScreenToWorldPoint(touchPositionScreenSpace);

        ballSerializedField.position = touchPositionWorldSpace;
    }

    private void LaunchBall()
    {
        ballSerializedField.isKinematic = false;
        ballSerializedField = null;

        Invoke(nameof(DisableSprintJoint), DetachDelay);
    }

    private void DisableSprintJoint()
    {
        springJointField.enabled = false;
        springJointField = null;
    }
}
