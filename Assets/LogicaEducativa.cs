using UnityEngine;
using TMPro;

public class LogicaEducativa : MonoBehaviour
{
	[Header("Configuración de Interfaz")]
	public TextMeshProUGUI textoInstruccion; // El texto central (Correcto/Incorrecto)

	[Header("Configuración de Sonido")]
	public AudioClip sonidoColision;

	private void OnTriggerEnter(Collider other)
	{
		// --- CASO: LETRA CORRECTA ---
		if (other.CompareTag("Correcto"))
		{
			// 1. Sonido
			ReproducirSonido();

			// 2. Puntaje (Llama al otro script)
			GameObject.Find("GameManager").GetComponent<ControlPuntaje>().SumarPuntos(10, Color.green);

			// 3. TEXTO (Lo que quieres mejorar)
			if (textoInstruccion != null)
			{
				textoInstruccion.text = "¡CORRECTO!";
				textoInstruccion.color = Color.green;
				Invoke("LimpiarTexto", 2f); // Borra el mensaje en 2 segundos
			}

			Destroy(other.gameObject);
		}

		// --- CASO: LETRA INCORRECTA ---
		else if (other.CompareTag("Incorrecto"))
		{
			// 1. Sonido
			ReproducirSonido();

			// 2. Puntaje
			GameObject.Find("GameManager").GetComponent<ControlPuntaje>().SumarPuntos(0, Color.red);

			// 3. TEXTO
			if (textoInstruccion != null)
			{
				textoInstruccion.text = "¡INCORRECTO!";
				textoInstruccion.color = Color.red;
				Invoke("LimpiarTexto", 2f);
			}

			Destroy(other.gameObject);
		}
	}

	void ReproducirSonido()
	{
		if (sonidoColision != null)
		{
			AudioSource.PlayClipAtPoint(sonidoColision, transform.position);
		}
	}

	void LimpiarTexto()
	{
		if (textoInstruccion != null) textoInstruccion.text = "";
	}
}