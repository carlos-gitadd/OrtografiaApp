using UnityEngine;
using TMPro; // 1. Cambiamos el sistema de UI por el de TextMeshPro

public class DialogoNPC : MonoBehaviour
{
	[Header("Configuración de UI")]
	public GameObject panelDialogo;
	public TextMeshProUGUI textoDialogo; // 2. Ahora es del tipo TextMeshProUGUI

	[Header("Mensaje")]
	[TextArea(3, 5)]
	public string mensaje;

	private void Start()
	{
		if (panelDialogo != null)
		{
			panelDialogo.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			MostrarTexto();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OcultarTexto();
		}
	}

	void MostrarTexto()
	{
		if (panelDialogo != null && textoDialogo != null)
		{
			textoDialogo.text = mensaje;
			panelDialogo.SetActive(true);
		}
	}

	void OcultarTexto()
	{
		if (panelDialogo != null)
		{
			panelDialogo.SetActive(false);
		}
	}
}