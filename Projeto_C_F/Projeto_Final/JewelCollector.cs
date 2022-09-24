using System;

/*! \mainpage Código em C#
 *
 * \section intro_sec Ian dos Anjos Melo Aguiar  |  N: 32
 *
 * \section RESUMO Resumo:
 *
 * Este é um projeto feito para as aulas de C# no curso de TECNOLOGIAS MICROSOFT disponibilizada pela Extencamp. O projeto consiste em um joguinho qual você controla um personagem que interagem com o ambiente e pega joias que valem alguns pontos.
 *
 */

class Program{
    
    //Chamando tudo -------------W-----------------------------------------------------------------------------------------
    /// <summary>
    /// O "Main" é o main, sem segredos.
    /// </summary>
    private static void Main(){

        // Objetos:
        var jogo = new Map();
        var personagem = new Robots();
        int fase = 1;

        // Adicionando as joias:
        jogo.mapa[1,9] = new Jewel(personagem, "Red");
        jogo.mapa[8,8] = new Jewel(personagem, "Red");
        jogo.mapa[9,1] = new Jewel(personagem, "Green");
        jogo.mapa[7,6] = new Jewel(personagem, "Green");
        jogo.mapa[3,4] = new Jewel(personagem, "Blue");
        jogo.mapa[2,1] = new Jewel(personagem, "Blue");

        // Adicionando os obstaculos:
        jogo.mapa[5,0] = new Obstacle("Water");
        jogo.mapa[5,1] = new Obstacle("Water");
        jogo.mapa[5,2] = new Obstacle("Water");
        jogo.mapa[5,3] = new Obstacle("Water");
        jogo.mapa[5,4] = new Obstacle("Water");
        jogo.mapa[5,5] = new Obstacle("Water");
        jogo.mapa[5,6] = new Obstacle("Water");

        jogo.mapa[5,9] = new Obstacle("Tree");
        jogo.mapa[3,9] = new Obstacle("Tree");
        jogo.mapa[8,3] = new Obstacle("Tree");
        jogo.mapa[2,5] = new Obstacle("Tree");
        jogo.mapa[1,4] = new Obstacle("Tree");

        //Chama o jogo: #################################################################################################
        (bool, int) running = (true, 5);
        bool running_2 = true;
        int bkp = 0;

        do {
            jogo.frame(personagem, running.Item2); // Atualiza o jogo   

            Console.WriteLine("Enter the command: ");
            string? command = Console.ReadLine();
  
            if(command is not null){
                if (command.Equals("quit")) {
                    running_2 = false;

                } if (command.Equals("g") ) {
                    bkp = running.Item2;
                    running = personagem.recarrega_energia(jogo);
                
                } else {
                    running = personagem.walk(command, jogo); 
                    bkp = running.Item2;                   
                }
            }
            
            if(running.Item2 == -9){fase++; jogo.proxima_fase(personagem); running.Item2 = bkp;}

        } while (running.Item1 && running_2 && fase < 20);
        
        if(fase == 20){Console.WriteLine("You Win!");} else {Console.WriteLine("Loser!");}

        }  
    }      

