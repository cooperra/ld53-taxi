using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : EnemyCarLogic
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.Conditions = Conditions.win;
        }
    }
}
