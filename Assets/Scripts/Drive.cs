using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    [SerializeField]float steerSpeed = 150f;
    [SerializeField]float moveSpeed = 10f;
    [SerializeField] float boostMultiplier = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move=0f;
        float steer=0f;
        float currentSpeed = moveSpeed;
        if (Keyboard.current.wKey.isPressed)
        {
            move=-1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move=1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer=-1;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            steer=1;
        }
        if (Keyboard.current.shiftKey.isPressed)
        {
            currentSpeed = moveSpeed * boostMultiplier;
        }
        float moveAmount=move*currentSpeed*Time.deltaTime;
        float steerAmount=steer*steerSpeed*Time.deltaTime;
        transform.Translate(moveAmount,0,0);
        transform.Rotate(0,0,steerAmount);
    }
}
