using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interfaccia comune a tutti i negozi
/// </summary>
public interface IShop
{
   // Ogni negozio ha bisogno di:
   string Name { get; set; } // Un nome
   List<int> WorkingDays { get; set; } // Giorni di apertura, valutavo se mettere un solo intero con il giorno di chiusira, ma una lista ci permette di creare un negozio esempio aperto a cazzo solo due giorni la settimana
   float OpeningTime { get; set; } // Un orario di apertura   
   float ClosingTime { get; set; } // Un orario di chiusura
}
