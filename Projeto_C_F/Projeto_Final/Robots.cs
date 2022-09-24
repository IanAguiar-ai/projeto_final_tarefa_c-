using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Robots -------------------------------------------------------

/// <summary>
/// É a classe que cuida do personagem, ou seja, sua posição, quantidades de joias, obtenção de joias e etc.
/// </summary>
public class Robots:Interativo{
    public int[] pos = new int[2] {0, 0}; //A posição inicial do robo é [0, 0]
    public int bag = 0; //Total de cada uma das joias, Red Green e Blue
    public int bag_total = 0; //Soma total das joias
    private int energia = 5;
    private List<Random> todas_joias = new List<Random>();

    public Robots(){
        this.forma = "ME";
    }

    /// <summary>
    /// É uma função que permite o jogador andar. Confere também se há colisões.
    /// </summary>
    /// <param name="tecla">É a tecla recebida.</param>
    /// <param name="OBJ1">É o mapa em que o personagem está.</param>
    /// <returns>Retorna um boleano que indica se o jogo acabou e a quantidade de energia restante do personagem.</returns>
    public (bool, int) walk(string tecla, Map OBJ1){ //Andar
        int x = this.pos[0];
        int y = this.pos[1];
        int x_ = x;
        int y_ = y;

        double tm_ = Math.Sqrt(OBJ1.mapa.Length);
        int tm = Convert.ToInt32(tm_);

        if(tecla == "w"){ 
            x = x - 1;
        }

        if(tecla == "a"){ 
            y = y - 1;
        }

        if(tecla == "s"){
            x = x + 1;
        }

        if(tecla == "d"){
            y = y + 1;
        }

        //Restrições dos obstaculos:
        //Bate nas bordas:
        if(x < 0 || x >= tm || y < 0 || y >= tm){ //tm é o máximo do mapa
            return (true, this.energia);
        }        

        //Colisão:
        if(OBJ1.mapa[x,y] is null){
            return (true, this.energia);
        }

        //Depois das restrições ele pode andar:
        this.pos[0] = x;
        this.pos[1] = y;
        OBJ1.mapa[x_,y_] = new itemmap();
        this.energia--;

        if(this.energia == 0){
            return (false, this.energia);
        }

        return (true, this.energia);
    }

    /// <summary>
    /// É uma função que cuida das joias que podem ser obtidas pelo personagem, além disso a função cuida da obtenção de energia por meio das árvores.
    /// </summary>
    /// <param name="OBJ1">É o mapa em que o personagem está. Precisamos conferir se existe algo em volta da posição do "Robots"(personagem).</param>
    /// <returns>Retorna um boleano que indica se o jogo acabou e a quantidade de energia restante do personagem.</returns>
    public (bool, int) recarrega_energia(Map OBJ1){ //Pega a joia
        int x = this.pos[0];
        int y = this.pos[1];

        //Recarrega a energia na árvore:
        try{
            if(OBJ1.mapa[x-1,y] is Obstacle && ((Obstacle)OBJ1.mapa[x-1,y]).tipo == "Tree"){
                this.energia = this.energia + 3;
            } 
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x+1,y] is Obstacle && ((Obstacle)OBJ1.mapa[x+1,y]).tipo == "Tree"){
                this.energia = this.energia + 3;
            }
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x,y-1] is Obstacle && ((Obstacle)OBJ1.mapa[x,y-1]).tipo == "Tree"){
                this.energia = this.energia + 3;
            }
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x,y+1] is Obstacle && ((Obstacle)OBJ1.mapa[x,y+1]).tipo == "Tree"){
                this.energia = this.energia + 3;
            }
        } catch(IndexOutOfRangeException){}  


        //Pega a joia:
        try{
            if(OBJ1.mapa[x-1,y] is Jewel){
                this.bag_total = this.bag_total + ((Jewel)OBJ1.mapa[x-1,y]).pontos;
                if (((Jewel)OBJ1.mapa[x-1,y]).pontos == 10){this.energia = this.energia + 5;}
                tirar_joia(((Jewel)OBJ1.mapa[x-1,y]).id);
                OBJ1.mapa[x-1,y] = new itemmap();
                this.bag++;
            } 
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x+1,y] is Jewel){
                this.bag_total = this.bag_total + ((Jewel)OBJ1.mapa[x+1,y]).pontos;
                if (((Jewel)OBJ1.mapa[x+1,y]).pontos == 10){this.energia = this.energia + 5;}
                tirar_joia(((Jewel)OBJ1.mapa[x+1,y]).id);
                OBJ1.mapa[x+1,y] = new itemmap();
                this.bag++;                
            }
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x,y-1] is Jewel){
                this.bag_total = this.bag_total + ((Jewel)OBJ1.mapa[x,y-1]).pontos;
                if (((Jewel)OBJ1.mapa[x,y-1]).pontos == 10){this.energia = this.energia + 5;}
                tirar_joia(((Jewel)OBJ1.mapa[x,y-1]).id);
                OBJ1.mapa[x,y-1] = new itemmap();
                this.bag++;
            }
        } catch(IndexOutOfRangeException){}

        try{
            if(OBJ1.mapa[x,y+1] is Jewel){
                this.bag_total = this.bag_total + ((Jewel)OBJ1.mapa[x,y+1]).pontos;
                if (((Jewel)OBJ1.mapa[x,y+1]).pontos == 10){this.energia = this.energia + 5;}
                tirar_joia(((Jewel)OBJ1.mapa[x,y+1]).id);
                OBJ1.mapa[x,y+1] = new itemmap();
                this.bag++;
            }
        } catch(IndexOutOfRangeException){}   

        if(this.todas_joias.Count <= 0){return (true, -9);}

        return (true, this.energia);
    } 

    /// <summary>
    /// Essa função serve para criar uma indentificação a joia e adicionala em uma lista.
    /// </summary>
    /// <param name="id">O "id" é a indentificação da joia, quando o personagem peagr um joia ela será indentificada pelo seu "id".</param>
    public void add_id_map(Random id){
        this.todas_joias.Add(id);
    }

    /// <summary>
    /// Essa função serve para tirar da lista a indentificação de uma joia.
    /// </summary>
    /// <param name="id">O "id"  é a indentificação da joia.</param>
    public void tirar_joia(Random id){
        this.todas_joias.Remove(id);
    }

}
