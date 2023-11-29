using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool canKillEnemies = false;

    public AudioSource swordSwing;

    void Update()
   
    {     
        if (Input.GetMouseButtonDown(0))
        {
            swordSwing.Play();
            canKillEnemies = true;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (canKillEnemies && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canKillEnemies = false;
    }
}
