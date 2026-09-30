using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BatterySystem : MonoBehaviour
{
    [SerializeField] float maxBattery = 100f;
    [SerializeField] float currentBattery;
    [SerializeField] float drainRate = 5f;
    [SerializeField] float boostDrainMultiplier = 2f;

    [Header("Referencias de UI")]
    [SerializeField] Slider batterySlider; 
    [SerializeField] GameObject gameOverPanel; 

    void Start()
    {
        currentBattery = maxBattery;
        
        // Nos aseguramos de que al iniciar el juego el panel de Game Over esté apagado
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        float currentDrain = drainRate;

        // Si presionamos Shift, gastamos más batería
        if (Keyboard.current != null && Keyboard.current.shiftKey.isPressed)
        {
            currentDrain *= boostDrainMultiplier;
        }

        currentBattery -= currentDrain * Time.deltaTime;

        // Actualizamos la barrita visual en tiempo real
        if (batterySlider != null)
        {
            batterySlider.value = currentBattery / maxBattery;
        }

        // Si la batería llega a cero, activamos el Game Over
        if (currentBattery <= 0)
        {
            currentBattery = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("¡Se acabó la energía! Game Over.");
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // ¡Aquí encendemos el panel!
        }
    }
}