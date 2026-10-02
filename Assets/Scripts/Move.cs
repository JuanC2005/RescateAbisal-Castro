using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float amplitud = 0.5f; // Qué tanto sube y baja
    [SerializeField] float velocidad = 2f;  // Qué tan rápido se mueve
    
    private Vector3 posicionInicial;

    void Start()
    {
        // Guardamos dónde pusiste a la medusa en el editor
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Usamos una onda matemática (Seno) para que suba y baje suavemente con el tiempo
        float nuevoY = posicionInicial.y + Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = new Vector3(posicionInicial.x, nuevoY, posicionInicial.z);
    }
}
