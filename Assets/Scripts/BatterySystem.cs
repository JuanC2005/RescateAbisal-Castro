using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        float currentDrain = drainRate;

        if (Keyboard.current != null && Keyboard.current.shiftKey.isPressed)
        {
            currentDrain *= boostDrainMultiplier;
        }

        currentBattery -= currentDrain * Time.deltaTime;

        if (batterySlider != null)
        {
            batterySlider.value = currentBattery / maxBattery;
        }

        if (currentBattery <= 0)
        {
            currentBattery = 0;
            GameOver();
        }
    }
    public void RecargarEnergia(float energiaQueOtorga)
    {
        currentBattery+=energiaQueOtorga;
        if (currentBattery >= maxBattery)
        {
            currentBattery=maxBattery;
        }
    }
    public void RestarEnergia(float energiaQueQuita)
    {
        currentBattery-=energiaQueQuita;
        if (currentBattery < 0)
    {
        currentBattery = 0;
    }
    }

    void GameOver()
    {
        Debug.Log("¡Se acabó la energía! Game Over.");
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ReiniciarJuego()
    {
        // Recarga la escena actual desde cero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}