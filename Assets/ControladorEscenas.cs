using UnityEngine;
using UnityEngine.SceneManagement; // Esta línea es la que permite cambiar de escenas

public class ControladorEscenas : MonoBehaviour
{
	// 1. Añadimos esta variable para referenciar tu PanelAyuda
	public GameObject panelAyuda;

	// Esta función la usaremos para los botones
	public void CambiarEscena(string nombreDelNivel)
	{
		SceneManager.LoadScene(nombreDelNivel);
	}

	// 2. Añadimos la función para mostrar el mensaje/panel de ayuda
	public void MostrarMensajeAyuda()
	{
		panelAyuda.SetActive(true);
	}

	// 3. Añadimos una función para cuando quieras cerrar el mensaje
	public void CerrarMensajeAyuda()
	{
		panelAyuda.SetActive(false);
	}
}