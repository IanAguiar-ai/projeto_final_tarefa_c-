using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Cria um obstaculo. Essa classe é importante para definimos o que deve ter uma "hitbox", ou seja, o que interage com o personagem.
/// </summary>
public class Obstacle:Interativo{

    /// <summary>
    /// A função construtora permite que criemos um obstaculo com algum tipo. Por exemplo: meu_obj = Obstacle("Water")
    /// </summary>
    /// <param name="tp">É uma string que identifica o tipo de obstáculo.</param>
    public Obstacle(string tp) {
        this.tipo = tp;
        
        if(tp == "Water"){
            this.forma = "##";
        }

        else if(tp == "Tree"){
            this.forma = "$$";
        }

    } 
}
