using UnityEngine;

public class CarroControl : MonoBehaviour
{
    [Header("Configuración del Vehículo")]
    public float velocidad = 15f;
    public float velocidadGiro = 70f;
    public float fuerzaFreno = 20f;

    private float movimientoVertical;
    private float movimientoHorizontal;

    // --- ESTA FUNCIÓN VA INDEPENDIENTE ---
    void Update()
    {
        // Capturar entradas del teclado (W/S o Flechas Arriba/Abajo)
        movimientoVertical = Input.GetAxis("Vertical");

        // Capturar entradas de giro (A/D o Flechas Izquierda/Derecha)
        movimientoHorizontal = Input.GetAxis("Horizontal");

        // Avanzar o retroceder
        transform.Translate(Vector3.forward * movimientoVertical * velocidad * Time.deltaTime);

        // Girar solo si el auto se está moviendo
        if (movimientoVertical != 0)
        {
            // Determinar dirección de giro (invertir si vamos marcha atrás)
            float direccionGiro = movimientoVertical > 0 ? 1f : -1f;
            transform.Rotate(Vector3.up * movimientoHorizontal * velocidadGiro * direccionGiro * Time.deltaTime);
        }
    } // <-- Aquí termina Update

    // --- ESTA FUNCIÓN TAMBIÉN VA INDEPENDIENTE, NO DENTRO DE UPDATE ---
    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el vehículo choca contra un objeto etiquetado como "Monstruo"
        // NOTA: Asegúrate de crear el Tag "Monstruo" y asignarlo a tus monstruos
        if (other.CompareTag("Monstruo"))
        {
            MonstruoOrtografico monstruo = other.GetComponent<MonstruoOrtografico>();
            if (monstruo != null)
            {
                // El script del monstruo ejecutará la entrega de puntos y palabras al GameManager
                // No necesitamos hacer nada más aquí, la lógica está en el script del monstruo.
            }
        }
    } // <-- Aquí termina OnTriggerEnter
}