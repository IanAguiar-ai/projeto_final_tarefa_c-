using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Jewel -----------------------------------------------------------
/// <summary>
/// O "Jewel" é a classe da joia, ele puxa as carácteristicas do interativo uma vez que ele tem que existir no mapa.
/// </summary>
public class Jewel:Interativo{
    //Deve puxar o .tipo e o .forma do Obstaculo
    public int pontos {get;}
    //Tipos de joia é: Red(100), Green(50), Blue(10)
    public Random id = new Random();
    //Indentificador quando nenhum mais existir acaba
    
    /// <summary>
    /// A função construtora do "Jewel" recebe o parâmetro "tipo", neste caso cada "tipo" tem uma "pontuação" diferente.
    /// </summary>
    /// <param name="OBJ1">O "OBJ1" é uma instancia de "Robots", ou seja, é o personagem. Ele está aqui para saber quais joias foram adicionadas.</param>
    /// <param name="tp">O "tp" é o tipo que o usuário manda quando chama a classe. por exemplo: meu_obj = Jewel("Red")</param>
    public Jewel(Robots OBJ1, string tp) {
        this.tipo = tp;
        
        if(tp == "Red"){
            this.pontos = 100;
            this.forma = "JR";
        }

        else if(tp == "Green"){
            this.pontos = 50;
            this.forma = "JG";
        }

        else if(tp == "Blue"){
            this.pontos = 10;
            this.forma = "JB";
        }

        OBJ1.add_id_map(id); //Adiciona id no mapa

    } 
}
