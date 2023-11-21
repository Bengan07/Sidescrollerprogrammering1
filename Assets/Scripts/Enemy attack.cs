using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public bool isPlayer = false;
    public int DamageValue = -1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isPlayer)
        {
            var enemyScript = collision.gameObject.GetComponent<EnemyGoomba>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(DamageValue);
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);
            }
        }
      


    }

}