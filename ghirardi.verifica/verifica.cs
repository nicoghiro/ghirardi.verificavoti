using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghirardi.verifica
{
    public class verifica
    {
        private string id;
        private string materia;
        private float voto;
        private DateTime data;
        public string Id
        {
            private set
            {
                if(value != null)
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
        public string Materia
        {
          private  set
            {
                if (value != null)
                {
                    materia = value;
                }
                else
                {
                    throw new Exception("inserire un valore nel campo");
                }
            }
            get
            {
                return materia;
            }
        }
        public float Voto
        {
            private set
            {
                if (value >= 0 && value <= 10)
                {
                    voto = value;
                }
            }
            get
            {
                return voto;
            }
        }
        public DateTime Data
        {
            private set
            {
                if(data != null) 
                { 
                data = value;
                }
                else
                {
                    throw new Exception();
                }
            }
            get
            {
                return data;
            }
        }
        public verifica(string id, string materia, float voto, DateTime data)
        {
            Id = id;
            Materia = materia;
            Voto = voto;
            Data = data;         
        }
        public void modificaVoto(float nvoto)
        {
         
                Voto = nvoto;
            
        }
        public void modificaMateria(string nmateria)
        {
            Materia = nmateria;
        }
        public void modificaData(DateTime ndata)
        {
            Data = ndata;
        }
        public override string ToString()
        {
            return Id + ";" + Materia + ";" + Voto + ";" + Data;
        }
    }
}
