using UnityEngine;
using TMPro;

public class ColeccionableVocal1 : MonoBehaviour
{
    [Header("Referencias de UI")]
    public GameObject panelVictoriaNivel2;  // Arrastra aquí tu panel de victoria
    public TextMeshProUGUI textoMensaje;     // Arrastra aquí el texto del panel

    void Start()
    {
        // Asegurarse de que el panel comience oculto al iniciar
        if (panelVictoriaNivel2 != null)
        {
            panelVictoriaNivel2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el carro (Player) colisiona con la vocal correcta
        if (other.CompareTag("Player"))
        {
            // 1. Mostrar el panel de victoria
            if (panelVictoriaNivel2 != null)
            {
                panelVictoriaNivel2.SetActive(true);
            }

            // 2. Asignar mensaje opcional por código
            if (textoMensaje != null)
            {
                textoMensaje.text = "¡EXCELENTE TRABAJO!\n\nCompletaste la palabra: LÁPIZ\n\n💡 REGLA: Es una palabra GRAVE porque lleva tilde al no terminar en N, S o Vocal.";
            }

            // 3. Desactivar la vocal para que desaparezca al tocarla
            gameObject.SetActive(false);
        }
    }
}