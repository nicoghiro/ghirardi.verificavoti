using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghirardi.verifica
{
    public class elenco
    {
        private string id;
     
        private const int maxlengt = 100;  
        private verifica[] registro= new verifica[maxlengt];
        private int currentLenght=0;
        private int checkid = 0;
        public int CurrentLenght
        {
            get
            {
                return currentLenght;
            }
        }
        public int Checkid
        {
            get
            {
                return checkid;
            }
        }
        public string Id
        {
            private set
            {
                if (value != null)
                {
                    id = value;
                }
                else
                {
                    throw new Exception("inserire un valore nel campo");
                }
            }
            get
            {
                return id;
            }
        }
        public verifica[] Registro
        {
            get
            {
                verifica[] p = new verifica[currentLenght];
                for (int i = 0; i < currentLenght; i++)
                {
                    p[i] = registro[i];
                }
                return p;
            }
           private set
            {
                if(value!= null)
                {
                    registro = value;
                }
                else
                {
                    throw new Exception("insirerire un valore valido");
                }
            }
        }
        public elenco(string id)
        {
            Id = id;
            
        }
        public void aggiungiVoto(string materia,float voto , DateTime data)
        {
            if (currentLenght != maxlengt) { 
            registro[currentLenght] = new verifica(checkid.ToString(), materia, voto, data);
            checkid++;
            currentLenght++;
            }
            else{
                throw new Exception("hai inserito il numero massimo di voti");
            }
        }
        public void rimuovi(verifica p)
        {
            for (int j = 0; j <= currentLenght; j++)
            {
                if (registro[j] != null && p.Id == registro[j].Id)
                {

                    int index = j;

                    for (int i = index; i < Registro.Length - 1; i++)
                    {
                        Registro [i] = registro[i + 1];
                    }
                    Array.Resize(ref registro, registro.Length - 1);
                    currentLenght--;
                    return;
                   
                    
                }
            }
            throw new Exception("prodotto insesistente");
        }
        public verifica ricerca(verifica p)
        {
            for (int j = 0; j <= currentLenght; j++)
            {
                if(registro[j] != null && p.Id == registro[j].Id)
                {
                    return registro[j];
                }
            }
            throw new Exception("valore non trovato");
        }
        public void modificaVoto(verifica p ,float voto)
        {
            for (int j = 0; j <= currentLenght; j++)
            {
                if (registro[j] != null && p.Id == registro[j].Id)
                {
                    registro[j].modificaVoto(voto);
                }
            }
        }
        public void modificaMateria(verifica p, string materia )
        {
            for (int j = 0; j <= currentLenght; j++)
            {
                if (registro[j] != null && p.Id == registro[j].Id)
                {
                    registro[j].modificaMateria(materia);
                }
            }
        }
        public void modificaData(verifica p, DateTime data)
        {
            for (int j = 0; j <= currentLenght; j++)
            {
                if (registro[j] != null && p.Id == registro[j].Id)
                {
                    registro[j].modificaData(data);
                }
            }
        }
        public float calcoloMedia(string materia)
        {
            float totale=0;
            float volte=0;
            for (int j = 0; j <= currentLenght; j++)
            {
                if (registro[j] != null && materia == registro[j].Materia)
                {
                    registro[j].modificaMateria(materia);
                    totale = totale + registro[j].Voto;
                    volte++;
                }
            }
           float media = totale/volte;
           return media;
        }

    }
}
