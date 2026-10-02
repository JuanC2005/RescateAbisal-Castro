using UnityEngine;

public class Recolectable : MonoBehaviour
{
    // Puedes elegir cuánta energía da cada basura desde el Inspector
    [SerializeField] float energiaQueOtorga = 20f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<BatterySystem>().RecargarEnergia(energiaQueOtorga);

            Debug.Log("¡Plástico recolectado! Energía recargada.");

            FindAnyObjectByType<UIManager>().SumarPlastico();
            Destroy(gameObject);
        }
    }
}