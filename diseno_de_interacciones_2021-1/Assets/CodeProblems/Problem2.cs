using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem2 : MonoBehaviour
{
    private string[] lista = {
        "Alvez Madrigal Abimael",
        "Hernandez Cano Isaac",
        "Astorga Sepulveda Cristian Alfredo",
        "Becerra Peraza Erick Arturo",
        "Tapia Olvera Jose Liam",
        "Chagala Jimenez Edgar Alberto",
        "Diaz Reynoso Luis Gerardo",
        "Santos Mendez Daniel",
        "Esqueda Garcia Luis Fernando",
        "Landa Luna Edgar Miguel",
        "Lazcano Ortiz Luis Eloy",
        "Lopez Moreno Nereo Cesar",
        "Luevano Cruz Araceli",
        "Rosas Ocampo Miguel Angel",
        "Martinez Suarez Sergio Alonso",
        "Martinez Villanueva Jorge Antonio",
        "Morales Rosales Ivan Alfredo",
        "Quintero Carrioza Felix Abraham",
        "Rodriguez Contreras Raul Arturo",
        "Raygoza de la Paz Brandon"
    };
    // Start is called before the first frame update
    void Start()
    {
        int respuesta = 0;
        ///Respuesta Correcta
        respuesta = estaInscrito("Hernandez Cano Isaac", lista);
        ///Respuesta Incorrecta
        //respuesta = estaInscrito("Ricardo Renteria", lista);
        if(respuesta > -1){
            Debug.Log("El alumno esta inscrito");
        }else{
            Debug.Log("El alumno no esta inscrito");
        }
    }

    // Update is called once per frame
    private int estaInscrito(string nombre, string[] lista){
        int respuesta = 0;

        System.Array.Sort(lista);
        //EL metodo de busqueda binaria tiene una complejidad de O(log n)
        respuesta = System.Array.BinarySearch(lista, nombre);

        return respuesta;
    }
}
