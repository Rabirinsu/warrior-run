using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterControl : MonoBehaviour
{


    public static float runSpeed = 1.5f;
    [SerializeField] private float swipeSpeed;
   
    private float startPosition;
    private float movePosition;

    private bool screenBoundRight;
    private bool screenBoundLeft;
    private void Awake()
    {
        Application.targetFrameRate = 30;

    }
    private void Update()
    {
        if (CharInteraction.CharState == CharInteraction.CharachterState.Idle || CharInteraction.CharState == CharInteraction.CharachterState.Attack)
            transform.SetPositionAndRotation(new Vector3(23, 12.18f, -1), Quaternion.Euler(0,90,0));

        if (CharInteraction.CharState == CharInteraction.CharachterState.Run && Monster.PlayerHealth >0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
            swipeCharachterDemo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("screenBoundRight"))
        {
            screenBoundRight = true;
            screenBoundLeft = false;
            
        }
        else if (other.gameObject.CompareTag("screenBoundLeft"))
        {
            screenBoundLeft = true;
            screenBoundRight = false;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("screenBoundRight") || other.gameObject.CompareTag("screenBoundLeft"))
            ResetScreenBounds();
    }
    private void ResetScreenBounds()
    {
        screenBoundLeft = false;
        screenBoundRight = false;
    }

    private void swipeCharachterDemo()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Stationary:
                    startPosition = Input.GetTouch(0).deltaPosition.x;
                    break;

                case TouchPhase.Moved:
                    movePosition = Input.GetTouch(0).deltaPosition.x;
                    break;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (movePosition > startPosition && !screenBoundRight)
                    transform.Translate(Vector3.right * swipeSpeed * Time.deltaTime);
                else if (!screenBoundLeft)
                    transform.Translate(Vector3.left * swipeSpeed * Time.deltaTime);

            }
        }
    }
}
