using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyGoomba myEnemyScript = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enemyScale = myEnemyScript.transform.localScale;
        enemyScale.x = -enemyScale.x;
        myEnemyScript.transform.localScale = enemyScale;
        myEnemyScript.MovementSign *= -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}