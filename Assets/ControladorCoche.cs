using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
	[Header("Configuración de Movimiento")]
	public float velocidadMaxima = 20f;
	public float fuerzaAceleracion = 10f;
	public float suavizadoMovimiento = 5f;

	[Header("Configuración de Giro")]
	public float anguloMaximoGiro = 30f;
	public float suavizadoGiro = 4f; // Controla qué tan rápido regresan las ruedas al centro

	private Rigidbody rb;
	private float entradaMovimiento;
	private float entradaGiro;

	private float velocidadActualSujeta;
	private float giroActualSuave;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// 1. Leer las entradas del teclado (W, S, A, D o Flechas)
		entradaMovimiento = Input.GetAxis("Vertical");   // Adelante / Atrás
		entradaGiro = Input.GetAxis("Horizontal");       // Izquierda / Derecha
	}

	void FixedUpdate()
	{
		ConfigurarMovimientoSuave();
		ConfigurarGiroSuave();
	}

	void ConfigurarMovimientoSuave()
	{
		// Calcula la velocidad objetivo basada en la entrada del jugador
		Vector3 velocidadObjetivo = transform.forward * entradaMovimiento * velocidadMaxima;

		// Aplica una interpolación lineal (Lerp) para cambiar de velocidad gradualmente
		Vector3 velocidadSuave = Vector3.Lerp(rb.linearVelocity, velocidadObjetivo, Time.fixedDeltaTime * suavizadoMovimiento);

		// Mantiene la gravedad intacta para que el coche no flote
		velocidadSuave.y = rb.linearVelocity.y;

		rb.linearVelocity = velocidadSuave;
	}

	void ConfigurarGiroSuave()
	{
		// Si el coche se está moviendo (hacia adelante o atrás), permite girar
		if (rb.linearVelocity.magnitude > 0.1f)
		{
			// Determina la dirección del giro (invierte si va en reversa)
			float direccionGiro = entradaMovimiento >= 0 ? 1f : -1f;

			// Interpola el giro actual hacia el giro objetivo de forma progresiva
			float giroObjetivo = entradaGiro * anguloMaximoGiro * direccionGiro;
			giroActualSuave = Mathf.Lerp(giroActualSuave, giroObjetivo, Time.fixedDeltaTime * suavizadoGiro);

			// Aplica la rotación al Rigidbody de manera limpia
			Quaternion rotacionY = Quaternion.Euler(0f, giroActualSuave * Time.fixedDeltaTime * 2f, 0f);
			rb.MoveRotation(rb.rotation * rotacionY);

			void OnTriggerEnter(Collider other)
			{
				// Si el coche toca una letra correcta
				if (other.CompareTag("Correcto"))
				{
					Debug.Log("¡Excelente! Palabra completada.");
					// Aquí puedes sumar puntos o mostrar un mensaje verde
					Destroy(other.gameObject); // La letra desaparece al recogerla
				}

				// Si el coche toca una letra incorrecta
				if (other.CompareTag("Incorrecto"))
				{
					Debug.Log("¡Oh no! Esa letra no lleva tilde.");
					// Aquí puedes restar vida o mostrar un mensaje rojo
					Destroy(other.gameObject);
				}
			}
		}
	}
}
