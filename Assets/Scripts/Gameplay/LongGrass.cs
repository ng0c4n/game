using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LongGrass : MonoBehaviour, IPlayerTrigger
{
    public void onPlayerTrigger(PlayerController player)
    {
        //10% chance to encounter wild pokemon in grass
        if (UnityEngine.Random.Range(1, 101) <= 10)
        {
            player.Character.Animator.IsMoving = false;
            GameController.Instance.StartBattle();
        }
    }
}
