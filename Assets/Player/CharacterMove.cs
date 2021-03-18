using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMove : NetworkBehaviour
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] float mouseSensitivity;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] private Animator animator = null;
    [SerializeField] bool DebugMode = false;
    Vector3 lastPosition;
    Transform myTransform;
    bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = cameraOffset;
            Camera.main.transform.rotation = Quaternion.identity;

        }
        else
        {

        }
        myTransform = transform;
        lastPosition = myTransform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal")*Time.deltaTime*5f;
        var z = Input.GetAxis("Vertical")*Time.deltaTime*5f;
        var mx = Input.GetAxis("Mouse X");
        if (!isLocalPlayer)
            return;

        if (DebugMode)
        {
            Camera.main.transform.localPosition = cameraOffset;
        }

        transform.Rotate(0, mx, 0);
        transform.Translate(x,0,z);

        if ( myTransform.position != lastPosition )
        {
          isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = myTransform.position;


        animator.SetBool("IsWalking", isMoving);
        //animator.SetBool("IsLeft", null);
        //animator.SetBool("IsRight", null);

    }
}
