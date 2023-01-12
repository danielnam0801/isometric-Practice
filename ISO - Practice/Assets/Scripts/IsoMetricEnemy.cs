using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoMetricEnemy : MonoBehaviour
{
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rb;
    public IsometricPlayerMovementController player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        player = GameObject.Find("Player_Isometric_Witch").GetComponent<IsometricPlayerMovementController>();
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;

        Vector2 inputVector = new Vector2(player.transform.position.x - currentPos.x, player.transform.position.y - currentPos.y);

        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rb.MovePosition(newPos);

    }
}
