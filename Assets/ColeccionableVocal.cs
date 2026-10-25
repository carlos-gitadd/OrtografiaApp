using UnityEngine;
using TMPro;

public class ColeccionableVocal : MonoBehaviour
{
    [Header("Referencias de UI")]
    public GameObject panelRetroalimentacion; // El panel que creaste en el Canvas
    public TextMeshProUGUI textoMensaje;      // El texto dentro de ese panel

    void Start()
    {
        // Al iniciar el juego, nos aseguramos de que el panel esté oculto
        if (panelRetroalimentacion != null)
        {
            panelRetroalimentacion.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta cuando el carro (Player) choca con la vocal
        if (other.CompareTag("Player"))
        {
            // 1. Activamos el panel en la pantalla
            if (panelRetroalimentacion != null)
            {
                panelRetroalimentacion.SetActive(true);
            }

            // 2. Mostramos el mensaje pedagógico
            if (textoMensaje != null)
            {
                textoMensaje.text = "¡EXCELENTE TRABAJO!\n\nCompletaste la palabra: CANCIÓN\n\n💡 REGLA: Es una palabra AGUDA porque la mayor fuerza de voz está en la última sílaba y termina en 'N'.";
            }

            // 3. Desactivamos la vocal para que desaparezca al tocarla
            gameObject.SetActive(false);
        }
    }
}