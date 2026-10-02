using UnityEngine;

public class Daño : MonoBehaviour
{
    [SerializeField] float energiaQueQuita = 25f;
    [SerializeField] float fuerzaKnockback = 10f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        
            collision.gameObject.GetComponent<BatterySystem>().RestarEnergia(energiaQueQuita);
            
            
            Vector2 direccionEmpuje = (collision.transform.position - transform.position).normalized;
            
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direccionEmpuje * fuerzaKnockback, ForceMode2D.Impulse);
        }
    }
}
