using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite4Unity3d;
using System.Linq;

public class Player
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int DoscaOpen { get; set; } //открыта ли доска
    public int inventOpen { get; set; } //количество открытых €чеек
    public int light { get; set; }
    public int hp { get; set; }
    public int money { get; set; }
    public int FPSValue { get; set; }
    public double MusicValue { get; set; }
    public double SEValue { get; set; }
}

public class Items
{
    [PrimaryKey, AutoIncrement] 
    public int Num { get; set; }
    public int Id { get; set; }
    public int Sprite { get; set; } //»зображение спрайта
    public string tag { get; set; } // тег
    public int attack { get; set; } // атака, если есть
    public int oblast { get; set; }// атака ближнего или дальнего типа
}

public class ItemsLobby
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int Delete { get; set; } // ƒл€ лобби, собрано или нет
}