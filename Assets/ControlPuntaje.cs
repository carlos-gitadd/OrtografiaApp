using UnityEngine;
using TMPro;

public class ControlPuntaje : MonoBehaviour
{
	public TextMeshProUGUI textoPuntos; // El objeto de texto que dice "+0 pts"
	private int puntosTotales = 0;
	void Start()
	{
		// Esto borra el "+10 pts" que pusiste de prueba en el Inspector
		textoPuntos.text = "";
	}
	public void SumarPuntos(int cantidad, Color colorTexto)
	{
		// Añadimos los puntos al total acumulado
		puntosTotales += cantidad;

		// Aplicamos el color (Verde para correcto, Rojo para incorrecto)
		textoPuntos.color = colorTexto;

		// Comprobamos si la cantidad recibida es 0 (Respuesta Incorrecta)
		if (cantidad == 0)
		{
			textoPuntos.text = "- 0 pts";
		}
		else
		{
			textoPuntos.text = "+" + cantidad + " pts";
		}

		// Hace que el texto del puntaje desaparezca después de 5 segundos
		Invoke("LimpiarTexto", 5f);
	}

	private void LimpiarTexto()
	{
		textoPuntos.text = "";
	}
}