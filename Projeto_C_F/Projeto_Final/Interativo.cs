using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// A classe "Interativo" é feita para armazenar o "tipo",o "tipo" é uma string que pode indicar uma caracteristica em alguma outra instancia. Além disso ela também armazena a "forma", 
/// a "forma" é a forma em que o objeto é printado no mapa. Em resumo todos objetos que devem existir no mapa tem uma herança da classe "Interatico".
/// </summary>
public class Interativo:itemmap{
    public string? tipo;
    protected string? forma;

    /// <summary>
    /// O override "ToString" indica que quando um plot de uma classe suscessora desta for "printada", ela deve "printar" em sua "forma" que é uma string.
    /// </summary>
    /// <returns>Ele retorna a sua "forma", que é uma string.</returns>
     public override string ToString(){
        return this.forma is null ?  "" : this.forma;
    }

}
