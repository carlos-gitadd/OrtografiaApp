using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class carro : MonoBehaviour
{
	[Header("Configuración de Movimiento")]
	public float velocidadMaxima = 2f;
	public float fuerzaAceleracion = 1f;    // Qué tan rápido alcanza la velocidad máxima
	public float fuerzaFrenado = 2f;        // Qué tan rápido se detiene al soltar las teclas

	[Header("Configuración de Giro Suave")]
	public float anguloMaximoGiro = 5f;     // El ángulo máximo que pueden torcer las ruedas
	public float suavizadoGiro = 2f;         // Qué tan rápido gira y regresa el volante al centro

	private Rigidbody rb;
	private float entradaMovimiento;
	private float entradaGiro;
	private float giroActualSuave;
	public TextMeshProUGUI letraA;
	public TextMeshProUGUI letraACorrecta;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		// Bloqueamos que el carro se vuelque de lado al chocar con las casas
		if (rb != null)
		{
			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}

	void Update()
	{
		// Captura las entradas del teclado
		entradaMovimiento = Input.GetAxis("Vertical");   // W / S o Flechas arriba/abajo
		entradaGiro = Input.GetAxis("Horizontal");       // A / D o Flechas izquierda/derecha

	}

    private void OnCollisionEnter(Collision collision) 
    {
		if (collision.gameObject.GetComponent<letraAmala>())
		{
			letraA.gameObject.SetActive(true);
			Invoke(nameof(OcultarTextoMalo), 3f);
			Destroy(collision.gameObject);
		}

		// 2. SI CHOCA CON LA LETRA BUENA (á)
		else if (collision.gameObject.GetComponent<buenaletraA>())
		{
			// Activamos el texto en pantalla de "Correcto +10 PTS"
			letraACorrecta.gameObject.SetActive(true);

			// Programamos que se oculte en 3 segundos
			Invoke(nameof(OcultarTextoBueno), 3f);

			// Destruimos la letra á de la escena
			Destroy(collision.gameObject);
		}
	}

	// Función para ocultar el texto de la letra mala
	void OcultarTextoMalo()
	{
		letraA.gameObject.SetActive(false);
	}

	// Función para ocultar el texto de la letra buena
	void OcultarTextoBueno()
	{
		letraACorrecta.gameObject.SetActive(false);
	}





void FixedUpdate()
	{
		if (rb == null) return;

		ConfigurarMovimientoSuave();
		ConfigurarGiroSuave();
	}

	void ConfigurarMovimientoSuave()
	{
		// 1. Calculamos cuál es la velocidad a la que queremos llegar
		Vector3 velocidadObjetivo = transform.forward * entradaMovimiento * velocidadMaxima;

		// 2. Decidimos si estamos acelerando o frenando para aplicar la fuerza correcta
		float tasaCambio = (entradaMovimiento != 0) ? fuerzaAceleracion : fuerzaFrenado;

		// 3. Movemos la velocidad actual hacia la velocidad objetivo de forma milimétrica y suave
		Vector3 velocidadSuave = Vector3.MoveTowards(rb.linearVelocity, velocidadObjetivo, tasaCambio * Time.fixedDeltaTime);

		// 4. Mantenemos la gravedad intacta para que no flote ni atraviese el suelo
		velocidadSuave.y = rb.linearVelocity.y;

		// 5. Aplicamos la velocidad final calculada al Rigidbody
		rb.linearVelocity = velocidadSuave;
	}

	void ConfigurarGiroSuave()
	{
		// El carro solo debe girar si se está moviendo (para simular realismo físico)
		// Usamos rb.linearVelocity.magnitude para saber si el coche tiene impulso
		if (rb.linearVelocity.magnitude > 0.5f)
		{
			// Invierte la dirección del giro si el carro va marcha atrás (reversa)
			float direccionMarcha = (entradaMovimiento >= 0) ? 1f : -1f;

			// Calculamos el giro objetivo basándonos en la tecla presionada
			float giroObjetivo = entradaGiro * anguloMaximoGiro * direccionMarcha;

			// Interpolamos de forma lineal (Lerp) para que el volante gire poco a poco
			giroActualSuave = Mathf.Lerp(giroActualSuave, giroObjetivo, suavizadoGiro * Time.fixedDeltaTime);

			// Convertimos ese giro suave en rotación física para el Rigidbody
			Quaternion rotacionY = Quaternion.Euler(0f, giroActualSuave * Time.fixedDeltaTime * 2f, 0f);
			rb.MoveRotation(rb.rotation * rotacionY);
		}
		else
		{
			// Si el carro está completamente quieto, el giro se estabiliza suavemente al centro
			giroActualSuave = Mathf.Lerp(giroActualSuave, 0f, suavizadoGiro * Time.fixedDeltaTime);
		}
	}
}
