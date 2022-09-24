using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Map -----------------------------------------------------------
/// <summary>
/// A classe Map cuida de armazenar todos os objetos no mapa, além disso elE é responsável pelas imagens geradas do jogo (frame).
/// </summary>
public class Map:itemmap{

    public Map(){
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 10; j++){
                if(mapa[i,j] == null){
                    mapa[i,j] = new itemmap();
                }
            }
        }
    }

    /// <summary>
    /// Printa o jogo, usa a posição do jogador e cuida de adicionar os icones os "--" nos espaços vazios.
    /// </summary>
    /// <param name="OBJ1">O "OBJ1" é uma instancia de Robots, é basicamente o jogador, precisamos dele para conferir onde o jogador está no mapa e se ao lado de sua posição existe
    /// algum objeto.</param>
    public void frame(Robots OBJ1, int energia){ //Atualiza o mapa

        double tm_ = Math.Sqrt(this.mapa.Length);
        int tm = Convert.ToInt32(tm_);
        //Montar a base do mapa toda vez é mais custoso computacionalmente mas fica mais simples de programar.
        for(int i = 0; i < tm; i++){
            for(int j = 0; j < tm; j++){
                try{
                    if(mapa[i,j] == null){
                        mapa[i,j] = new itemmap();
                    }
                } catch(IndexOutOfRangeException) {}
            }
        }

        //Printar personagem: "ME":
        int p_x = OBJ1.pos[0];
        int p_y = OBJ1.pos[1];
        this.mapa[p_x,p_y] = OBJ1;
        
        //Faz o frame:
        for(int i = 0; i < tm; i++){
            for(int j = 0; j < tm; j++){
                    Console.Write("{0} " ,mapa[i,j]);
            }
            Console.WriteLine("");
        }

        Console.WriteLine("Bag total items: {0} | Bag total value: {1}  |  Energi: {2}", OBJ1.bag, OBJ1.bag_total, energia);
    }

    /// <summary>
    /// A função "proxima_fase" basicamente cuida do processo de geração de novos mapas, esses mapas tem sempre tamanhos difetentes e neles são adicionados os obstaculos e as joias, quanto maior
    /// o nível da fase, mais objetos ele adiciona.
    /// </summary>
    /// <param name="OBJ1">O "OBJ1" é uma instancia da classe Robots, em outras palavras é o jogados, ele entra nessa função para que a geração de objetos não sobreponha ele no mapa.</param>
    public void proxima_fase(Robots OBJ1){

        double tm_ = Math.Sqrt(this.mapa.Length);
        int tm = Convert.ToInt32(tm_);

        //Limpar tudo:
        for(int i = 0; i < tm; i++){
            for(int j = 0; j < tm; j++){
                try{this.mapa[i,j] = new itemmap();} catch(IndexOutOfRangeException){}
            }
        }

        //Muda o tamanho do array em 1:
        mapa = new itemmap[tm+1,tm+1];

        //Colocar aleatóriamente os obstaculos:

        //Joias:
        double j1 = tm * tm * 0.07;
        for(int i = 0; i < j1; i++){
            Random alt = new Random();
            int p_x = alt.Next(0, tm);
            int p_y = alt.Next(0, tm );
            int tipo_ = alt.Next(0, 3); //0, 1 e 2
            string tipo = "Green";

            if(tipo_ == 0){tipo = "Red";}
            if(tipo_ == 1){tipo = "Green";}
            if(tipo_ == 2){tipo = "Blue";}

            if(this.mapa[p_x, p_y] is not Jewel && this.mapa[p_x, p_y] is not Obstacle && this.mapa[p_x, p_y] is not Robots){
                this.mapa[p_x, p_y] = new Jewel(OBJ1, tipo);
            }
        }

        //Arvores:
        double j2 = tm * tm * 0.08;
        for(int i = 0; i < j2; i++){
            Random alt = new Random();
            int p_x = alt.Next(0, tm+1);
            int p_y = alt.Next(0, tm+1);

            if(this.mapa[p_x, p_y] is not Jewel && this.mapa[p_x, p_y] is not Obstacle && this.mapa[p_x, p_y] is not Robots){
                this.mapa[p_x, p_y] = new Obstacle("Tree");
            }
        }

        //Agua:
        double j3 = tm * tm * 0.06;
        for(int i = 0; i < j3; i++){
            Random alt = new Random();
            int p_x = alt.Next(0, tm+1);
            int p_y = alt.Next(0, tm+1);

            if(this.mapa[p_x, p_y] is not Jewel && this.mapa[p_x, p_y] is not Obstacle && this.mapa[p_x, p_y] is not Robots){
                this.mapa[p_x, p_y] = new Obstacle("Water");
            }
        }
    
    }

}