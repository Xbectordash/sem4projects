using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private characterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied ;
    public bool is_Player;

    private HealthUI health_UI;
    void Awake()
    {
        animationScript = GetComponentInChildren<characterAnimation>();
        if(is_Player ) { health_UI = GetComponent<HealthUI>(); }
       
    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;
        health -= damage;

       //   Display health_UI
       health_UI.DisplayHealth(health);

        if (health <= 0f)
        {
            animationScript.DEATH();
            characterDied = true;

            if(is_Player)
            {
              GameObject.FindWithTag(Tags.ENEMY_TAG)
                    .GetComponent<EnemyMovement>().enabled = false;
            }
            return;
             
        }
        if(!is_Player)
        {
            if(knockDown)
            {
                if(Random.Range(0,2) > 0)
                {
                    animationScript.KnockDown();
                }
                else
                {
                    if(Random.Range(0,3)>1)
                    {
                        animationScript.HIT();
                   }
                }
            }
        }

    }

}
