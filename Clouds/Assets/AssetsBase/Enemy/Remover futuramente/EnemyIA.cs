using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string playerTag = "Player"; // armazena a tag player
    public float velocidade = 5f; // velocidade
    public Transform playerTransform; //cria uma variavel para armazenar a posi��o do player em vector 2
    private ConeDeVisao coneDeVisao; //variavel para armazenar as informa��es do cone

    private void Awake()
    {
        coneDeVisao = GetComponentInChildren<ConeDeVisao>(); // pega as informa��es do codigo do cone no objeto filho
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag); //pega as informa��es do objeto player contidos no player que tiver a tag player
        playerTransform = playerObject.transform; // pega as informa��es da posi��o do player e enviar para a variavel playertransform
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, coneDeVisao.raio);// recebe dois par�metros: o primeiro � a posi��o do centro do c�rculo de verifica��o de colis�o, que � obtida atrav�s de transform.position (a posi��o do objeto que possui esse script). O segundo par�metro � o raio do c�rculo de verifica��o, que � obtido de coneDeVisao.raio (uma vari�vel definida no script ConeDeVisao).
        Vector2 direcao = playerTransform.position - transform.position; //pega a diferen�a entre playe e o inimigo
        


        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(playerTag) && (direcao.y >= 1.30 || direcao.x >= 1.30 || direcao.x <= -1.30 || direcao.y <= -1.30))// verifica se o player esta dentro do circulo e se esta ou n�o encostando no player
            {
               Debug.Log("Player Detectado");
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidade * Time.deltaTime); // anda em dire��o ao player
            } else if (collider.CompareTag(playerTag))
            {
               Debug.Log("ATACANDO"); // se estiver encostando no player e dentro da area do collider, ia atacar
            }
        }
    }
}

 



