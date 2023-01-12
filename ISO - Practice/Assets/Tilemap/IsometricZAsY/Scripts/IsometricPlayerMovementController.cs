using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;
    private bool isSkillButtonClick;
    private bool canRE = true;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSkillButtonClick && canRE) {
            isSkillButtonClick = false;
            canRE = false;
            StartCoroutine("PlayerMoveUp");
        }
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    IEnumerator PlayerMoveUp()
    {
        movementSpeed = movementSpeed * 3;
        yield return new WaitForSeconds(10f);
        movementSpeed = movementSpeed / 3;
    }

    public void OnSkillClick()
    {
        isSkillButtonClick=true;
        StartCoroutine("Can");
    }

    IEnumerator Can()
    {
        yield return new WaitForSeconds(30f);
        canRE=true;
    }
}
