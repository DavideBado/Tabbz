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
        [Range(0,100)] public int Reputazione;
        [Range(0, 100)] public int Figosit;
        [Range(0, 100)] public int ProfittoScolastico;
        [Range(0, 100)] public int ImpegnoLavoro;
        public int Stipendio;
        public BikeBase Bike;
        public FactoryConfigData CurrentFactory;
        public List<ClothingConfigData> clothings = new List<ClothingConfigData>();        
        // telefono

        /// <summary>
        /// Setta i valori iniziali del tabboz
        /// </summary>
        public void Init()
        {
            Nome = "Tizio";
            Cognome = "Caio";
            RapportoConLaTipa = 0;
            Soldi = 0;
            Reputazione = 0;
            Figosit = 0;
            ProfittoScolastico = 0;
            ImpegnoLavoro = 0;
            Stipendio = 0;
            Bike = null;
            CurrentFactory = null;
        }
    }
}
