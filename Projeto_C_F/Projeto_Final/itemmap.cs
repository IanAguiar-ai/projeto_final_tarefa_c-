using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// A classe "itemmap" serve para poder aplicar o polimorfismo no mapa, muitas das classes herdam ele, assim o mapa pode assumir a forma de várias classes em vez de ser da forma genérica "Objects". 
/// </summary>
public class itemmap{
    public itemmap[,] mapa = new itemmap[10,10];  

    public string vazio = "--";

    public override string ToString(){
        return this.vazio is null ?  "--" : this.vazio;
    }
}