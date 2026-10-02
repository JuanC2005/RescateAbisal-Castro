using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoRecolectado;
    [SerializeField] TextMeshProUGUI textoInventario;
    
    private int plasticosRecolectados = 0;
    public int plasticosInventario = 0;
    private int totalPlasticosNivel;
    void Start()
    {
        totalPlasticosNivel = GameObject.FindGameObjectsWithTag("Recolectable").Length;
        
        textoRecolectado.text = "Plasticos Recolectados: 0 / " + totalPlasticosNivel;
    }
    
    public void SumarPlastico()
    {
        plasticosRecolectados++;
        plasticosInventario++;
        
        string mensajeEstacion = ""; 
        
        if (plasticosInventario >= 7)
        {
            mensajeEstacion = "\n\n\n¡Reuniste 7 plásticos, puedes crear una estación!\n\n\nPRESIONA 'E' PARA DESLEGAR TU ESTACION DE REGARGA"; 
        }
        
        textoInventario.text = "Plasticos en Inventario: " + plasticosInventario + mensajeEstacion;
        textoRecolectado.text = "Plasticos Recolectados: "+plasticosRecolectados+"/ " + totalPlasticosNivel;
        
        Debug.Log("¡UI Actualizada! Llevas un total de: " + plasticosRecolectados);
    }
    public void GastarPlasticos(int costo)
    {
        plasticosInventario -= costo;
        textoInventario.text = "Plasticos en Inventario: " + plasticosInventario;
    }
}