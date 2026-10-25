using UnityEngine;
using TMPro;

public class VocalIncorrecta : MonoBehaviour
{
    [Header("Panel de Error")]
    public GameObject panelError;          // Arrastra aquí tu PanelError
    public TextMeshProUGUI textoError;     // Arrastra aquí el texto del panel de error

    void Start()
    {
        // Asegurarse de que el panel de error comience oculto
        if (panelError != null)
        {
            panelError.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el carro (Player) colisiona con la vocal incorrecta
        if (other.CompareTag("Player"))
        {
            // 1. Mostrar el panel de error
            if (panelError != null)
            {
                panelError.SetActive(true);
            }

            // 2. Asignar el mensaje educativo de corrección
            if (textoError != null)
            {
                textoError.text = "¡CASI LO LOGRAS!\n\nLa palabra correcta es CANCIÓ_.\n\n❌ Recuerda que necesita una vocal con tilde (Ó) para marcar la mayor fuerza de voz.";
            }

            // 3. Desactivar la vocal incorrecta para que desaparezca al tocarla
            gameObject.SetActive(false);
        }
    }
}