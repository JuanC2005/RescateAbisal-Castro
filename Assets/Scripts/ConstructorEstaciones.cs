using UnityEngine;
using UnityEngine.InputSystem; // ¡La llave maestra del sistema moderno!

public class ConstructorEstaciones : MonoBehaviour
{
    [SerializeField] GameObject estacionPrefab;

    void Update()
    {
        UIManager ui = FindAnyObjectByType<UIManager>();

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && ui.plasticosInventario >= 7)
        {
            Instantiate(estacionPrefab, transform.position + new Vector3(0, -2f, 0), Quaternion.identity);
            ui.GastarPlasticos(7);
        }
    }
}