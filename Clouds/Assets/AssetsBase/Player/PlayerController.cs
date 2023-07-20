using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IDamageable))] //obriga que o player tenha o component IDamageable
public class PlayerController : MonoBehaviour
{
    IDamageable damageable; // crio uma variavel da interface IDamageable com o nome damageable

    public float speed;
    public Animator anim;

    private void Start()
    {
        damageable = GetComponent<IDamageable>(); // atribuo a variavel as informa��es da interface

        damageable.DeathEvent += OnDeath; // 3� fase = quando esse evento for chamado execute a fun��o OnDeath

    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }
    void Update()
    {

        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); // controle de input
        // Controle de anima��es
        anim.SetFloat("Horizontal", moviment.x);
        anim.SetFloat("Vertical", moviment.y);
        anim.SetFloat("Velocidade", moviment.magnitude);
        // Fim Controle Anima��es
        transform.position = transform.position + moviment * speed * Time.deltaTime;
    }

    private void OnDeath() //Fun��o que mata o objeto 
    {
         Debug.Log("TOMEI DANO");
          Destroy(gameObject);
    }
}
