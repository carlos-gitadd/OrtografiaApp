using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    // Función pública para cambiar de escena por su nombre exacto
    public void IrANivel(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}