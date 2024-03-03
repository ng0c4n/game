using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Sprite sprite;

    private Vector2 input;
    private Character character;
    private void Awake()
    {
        character = GetComponent<Character>();
    }
    public void HandleUpdate()
    {
        if(!character.IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                StartCoroutine(character.Move(input, OnMoveOver));
            }
        }
        character.HandleUpdate();
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayer.i.InteractableLayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact(transform);
        }
    }

    private void OnMoveOver()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, character.OffSetY), 0.2f, GameLayer.i.TriggerableLayer);
        
        foreach(var collider in colliders)
        {
            var triggerable = collider.GetComponent<IPlayerTrigger>();
            if(triggerable != null) 
            {
                triggerable.onPlayerTrigger(this);
                break;
            }
        }
    }

    public string Name
    {
        get => name;
    }
    public Sprite Sprite
    {
        get => sprite;
    }
    public Character Character => character;
}
