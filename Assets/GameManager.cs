using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración de Puntuación")]
    public int puntosBaseNivelesAnteriores = 20;
    public int puntosNivel3 = 0;
    public int puntosTotales = 20;

    [Header("Interfaz de Usuario (UI)")]
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoPalabraAguda;
    public TextMeshProUGUI textoPalabraGrave;
    public GameObject panelVictoriaFinal; // Panel emergente al ganar

    private int monstruosAtropellados = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Ocultar el panel de victoria al iniciar la escena si está asignado
        if (panelVictoriaFinal != null)
        {
            panelVictoriaFinal.SetActive(false);
        }

        // Establecer textos iniciales
        if (textoPalabraAguda != null)
            textoPalabraAguda.text = "AGUDA: CAMI_N";

        if (textoPalabraGrave != null)
            textoPalabraGrave.text = "GRAVE: _RBOL";

        ActualizarUI();
    }

    public void AtropellarMonstruo(string tipoPalabra, string vocalObtenida)
    {
        // Cada monstruo derrotado suma 10 puntos
        puntosNivel3 += 10;
        puntosTotales = puntosBaseNivelesAnteriores + puntosNivel3;
        monstruosAtropellados++;

        // Actualizar el texto según la palabra completada
        if (tipoPalabra.ToLower() == "aguda")
        {
            if (textoPalabraAguda != null)
                textoPalabraAguda.text = "AGUDA: CAMI" + vocalObtenida + "N ¡COMPLETADA!";
        }
        else if (tipoPalabra.ToLower() == "grave")
        {
            if (textoPalabraGrave != null)
                textoPalabraGrave.text = "GRAVE: " + vocalObtenida + "RBOL ¡COMPLETADA!";
        }

        ActualizarUI();

        // Al atropellar ambos monstruos se alcanzan los 40 puntos finales
        if (monstruosAtropellados >= 2)
        {
            FinalizarJuego();
        }
    }

    void ActualizarUI()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = "PUNTOS: " + puntosTotales + " / 40";
        }
    }

    void FinalizarJuego()
    {
        StartCoroutine(EsperarYMostrarVictoria());
    }

    IEnumerator EsperarYMostrarVictoria()
    {
        Debug.Log("¡Segunda palabra completada! Esperando 3 segundos para mostrar el panel de victoria...");

        // Espera 3 segundos reales
        yield return new WaitForSeconds(3f);

        // Muestra el panel de victoria
        if (panelVictoriaFinal != null)
        {
            panelVictoriaFinal.SetActive(true);
        }

        Debug.Log("¡Felicidades! Has completado Ortografía App con un total de " + puntosTotales + " puntos.");
    }
}