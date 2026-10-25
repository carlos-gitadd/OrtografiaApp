using UnityEngine;

public class SeguirCarro : MonoBehaviour
{
	// Aquí arrastraremos el carro en el Inspector
	public Transform objetivo;

	// Distancia a la que se mantendrá la cámara (puedes cambiarla en el Inspector)
	public Vector3 distancia = new Vector3(0, 5, -10);

	void LateUpdate()
	{
		if (objetivo != null)
		{
			// Mueve la cámara a la posición del carro más la distancia configurada
			transform.position = objetivo.position + distancia;

			// Hace que la cámara siempre mire en dirección al carro
			transform.LookAt(objetivo);
		}
	}
}
