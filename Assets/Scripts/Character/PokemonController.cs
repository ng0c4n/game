using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonController : MonoBehaviour
{
   /* public Transform playerTransform; // Reference to the Player's Transform
    public float followSpeed = 2f; // Speed at which the Pokemon follows the player
    public Animator pokemonAnimator; // Reference to the Animator component

    private Vector2 lastPlayerPosition;
    private Vector2 movement;

    private void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Initialize lastPlayerPosition with the player's initial position
        lastPlayerPosition = playerTransform.position;
    }

    private void Update()
    {
        FollowPlayer();
        AnimatePokemon();
    }

    void FollowPlayer()
    {
        // Calculate the movement vector
        movement = playerTransform.position - transform.position;

        // Move the Pokemon towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);

        // Update lastPlayerPosition for the next frame
        lastPlayerPosition = playerTransform.position;
    }

    void AnimatePokemon()
    {
        // Use the movement vector to determine the direction
        pokemonAnimator.SetFloat("MoveX", movement.x);
        pokemonAnimator.SetFloat("MoveY", movement.y);

        // Check if the Pokemon is moving to toggle the walking animation
        if (movement != Vector2.zero)
        {
            pokemonAnimator.SetBool("IsMoving", true);
        }
        else
        {
            pokemonAnimator.SetBool("IsMoving", false);
        }
    }*/
}
