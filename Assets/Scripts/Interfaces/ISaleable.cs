using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interfaccia comune a tutti gli oggetti vendibili
/// </summary>
public interface ISaleable
{
    // Ogni vendibile necessita di:
    string Name{ get; set; } // Un nome
    Sprite Icon{ get; set; } // Un immagine
    int Price{ get; set; }   // Un prezzo
    string Description(); // Una descrizione
    void EquipMe();
}
