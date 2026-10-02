using UnityEngine;

public class EstacionEnergia : MonoBehaviour
{
    [SerializeField] float energiaQueOtorga = 5f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<BatterySystem>().RecargarEnergia(energiaQueOtorga*Time.deltaTime);
        }
    }
}
