using UnityEngine;

public class MonstruoOrtografico : MonoBehaviour
{
    [Header("Tipo de Palabra")]
    [Tooltip("Escribe 'aguda' o 'grave'")]
    public string tipoPalabra = "aguda"; 

    [Tooltip("Vocal con tilde que entrega este monstruo")]
    public string vocalAcentuada = "Ó";

    [Header("Efectos al Colisionar")]
    public GameObject efectoExplosion;
    public AudioClip sonidoAtropello;

    private bool yaColisiono = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el carro tenga el Tag "Player"
        if (other.CompareTag("Player") && !yaColisiono)
        {
            yaColisiono = true;

            // Sonido
            if (sonidoAtropello != null)
            {
                AudioSource.PlayClipAtPoint(sonidoAtropello, transform.position);
            }

            // Partículas/Efecto visual
            if (efectoExplosion != null)
            {
                Instantiate(efectoExplosion, transform.position, Quaternion.identity);
            }

            // Notificar al GameManager del Nivel 3
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AtropellarMonstruo(tipoPalabra, vocalAcentuada);
            }

            // Eliminar monstruo del mapa
            Destroy(gameObject);
        }
    }
}