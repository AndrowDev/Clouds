using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Implementa��o especifica do da interface IDamageable
public class DeathOnDamage : MonoBehaviour, IDamageable // tudo que tiver este script pode receber dano
{
    public bool IsDead { get; private set; } // outros componentes poder�o acessar a variavel mas s� � possivel alterar o valor por scripts

    //o que ira toamr dano ira se inscrever no evento DeathEvent
    public event Action DeathEvent;
    private void Awake()
    {
        IsDead = false;
    }

    public void TakeDamage(int damage)  
    {
        IsDead = true;
        DeathEvent.Invoke(); //a fun��o executa o evento de morte avisando todos que est�o incritos no evento de que ele foi executado
    }
}

// 2.1� quando o TakeDamage for executado aviso para todos que est�o incritos nele que o DeathEvent foi chamado
