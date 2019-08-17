using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    public class Tabboz : MonoBehaviour
    {
        public string Nome;
        public string Cognome;
        public int RapportoConLaTipa;
        public int Soldi;
        public int Reputazione;
        public int Figosit;
        public int ProfittoScolastico;
        public BikeBase Bike;
        // telefono
        // lavoro

        public void Init()
        {
            Nome = "Tizio";
            Cognome = "Caio";
            RapportoConLaTipa = 0;
            Soldi = 0;
            Reputazione = 0;
            Figosit = 0;
            ProfittoScolastico = 50;
            Bike = null;
        }
    }
}
