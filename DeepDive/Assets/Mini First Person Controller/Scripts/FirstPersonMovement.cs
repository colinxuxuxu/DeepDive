using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [Header("FootStepAudio")]
    public string currentTexture;
    public Sound dirt;
    public Sound grass;
    public SoundEmitter currEmitter;



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

       

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);

        //playing the correct footstep
        if (Mathf.Abs(rigidbody.linearVelocity.y) > 0f || Mathf.Abs(rigidbody.linearVelocity.x) > 0f)
        {
            if (currentTexture.Equals("dirt"))
            {  
                if(currEmitter == null)
                {
                    currEmitter = SoundManagerSingleton.Instance.PlaySound(dirt);
                }
                else
                {
                    if(!(currEmitter.soundData.audioName.Equals("dirt")))
                    {
                        currEmitter.StopSound();
                        currEmitter = SoundManagerSingleton.Instance.PlaySound(dirt);
                    }
                }
            }
            if (currentTexture.Equals("Grass"))
            {
                if(currEmitter == null)
                {
                    currEmitter = SoundManagerSingleton.Instance.PlaySound(grass);
                }
                else
                {
                    if (!(currEmitter.soundData.audioName.Equals("Grass")))
                    {
                        currEmitter.StopSound();
                        currEmitter = SoundManagerSingleton.Instance.PlaySound(grass);
                    }
                }
            }
        }
        else// we stop the current footstep sound
        {
            if (currEmitter != null)
            {
                currEmitter.StopSound();
            }
        }
    }
}