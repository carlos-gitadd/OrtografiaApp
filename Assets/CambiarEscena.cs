using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [Header("Control de Audio")]
    public AudioSource musicaFondo;

    // --- 1. NAVEGACIÓN DE ESCENAS (Botón JUGAR / REGRESAR) ---
    public void CargarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    // --- 2. CONTROL DE PANELES (OPCIONES, CRÉDITOS, AYUDA) ---
    public void MostrarPanel(GameObject panel)
    {
        if (panel != null) panel.SetActive(true);
    }

    public void OcultarPanel(GameObject panel)
    {
        if (panel != null) panel.SetActive(false);
    }

    // --- 3. SALIDA DIRECTA (Botón SALIR) ---
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    // --- 4. CONTROL DE VOLUMEN (Slider del Panel Opciones) ---
    public void CambiarVolumenMusica(float volumen)
    {
        if (musicaFondo != null)
        {
            musicaFondo.volume = Mathf.Clamp01(volumen);
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioSource 'musicaFondo' en el Inspector.");
        }
    }
}