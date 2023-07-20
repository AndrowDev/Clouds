using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tudo que pode tomar dano acessara essa interface
public interface IDamageable 
{
    void TakeDamage(int damage); //chama a fun��o o TakeDamage
    event Action DeathEvent; //action significa que isso � uma fun��o void
    bool IsDead { get; } // tudo que pode tomar dano tera que ter o booleano avisando se esta morto ou n�o
}

// 2� fase = chama a fun��o TakeDamage