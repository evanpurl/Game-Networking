using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMoveNew : NetworkBehaviour
{
    [SerializeField] private CharacterController controller = null;

    [SerializeField] private float movementSpeed = 5f;

    [ClientCallback]
    private void Update() {
        if (!hasAuthority) {return; }

        var movement = new Vector3();

        if (Input.GetKeyDown("w")) { movement.z += 1; }
        if (Input.GetKeyDown("s")) { movement.z -= 1; }
        if (Input.GetKeyDown("a")) { movement.x -= 1; }
        if (Input.GetKeyDown("d")) { movement.x += 1; }

        controller.Move(movement * movementSpeed * Time.deltaTime);

        if (controller.velocity.magnitude > 0.2f) {
        transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
