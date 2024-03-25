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
    public int DoscaOpen { get; set; } //������� �� �����
    public int inventOpen { get; set; } //���������� �������� �����
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
    public int Sprite { get; set; } //����������� �������
    public string tag { get; set; } // ���
    public int attack { get; set; } // �����, ���� ����
    public int oblast { get; set; }// ����� �������� ��� �������� ����
}

public class ItemsLobby
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int Delete { get; set; } // ��� �����, ������� ��� ���
}