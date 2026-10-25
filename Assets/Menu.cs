using UnityEngine;
using UnityEngine.SceneManagement; // Importante para manejar escenas

public class ControladorMenu : MonoBehaviour
{
	// Esta función se activará al tocar el botón
	public void RegresarAlMenu()
	{
		// Cambia "Menu" por el nombre exacto de tu escena del menú principal
		SceneManager.LoadScene("Menu");
	}
}