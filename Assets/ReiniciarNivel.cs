using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarNivel : MonoBehaviour
{
    // Función para reiniciar la escena actual desde cero
    public void ReiniciarEscenaActual()
    {
        // Obtiene el nombre de la escena activa actualmente y la vuelve a cargar
        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(escenaActual);
    }
}