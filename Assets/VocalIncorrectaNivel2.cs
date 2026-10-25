using UnityEngine;
using TMPro;

public class VocalIncorrectaNivel2 : MonoBehaviour
{
    [Header("Panel de Error Nivel 2")]
    public GameObject panelErrorNivel2;    // Arrastra aquí tu PanelErrorNivel2
    public TextMeshProUGUI textoError;       // Arrastra aquí el texto del panel

    void Start()
    {
        // Asegurarse de que el panel de error comience oculto
        if (panelErrorNivel2 != null)
        {
            panelErrorNivel2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el carro (Player) colisiona con la vocal incorrecta
        if (other.CompareTag("Player"))
        {
            // 1. Mostrar el panel de error
            if (panelErrorNivel2 != null)
            {
                panelErrorNivel2.SetActive(true);
            }

            // 2. Asignar el mensaje educativo de corrección
            if (textoError != null)
            {
                textoError.text = "¡INCORRECTO!\n\nRecuerda: 'LÁPIZ' lleva tilde en la vocal 'Á' porque es una palabra grave que no termina en N, S o Vocal.";
            }

            // 3. Desactivar la vocal incorrecta para que desaparezca al tocarla
            gameObject.SetActive(false);
        }
    }
}