using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBITS.Google.API.Calendar
{
    public class Evento
    {
        public string Titulo { get; set; }
        public  string Localizacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public Recorrencia Recorrencia { get; set; }
        public int TotalRecorrencia { get; set; }

        private Dictionary<string, int> _frequencia;
        internal Dictionary<string,int> Frequencia
        {

            get
            {
                _frequencia = new Dictionary<string, int>();
                string recorrencia = "";
                switch(this.Recorrencia)
                {
                    case Recorrencia.Diaria:
                        recorrencia = "DAILY";
                        break;
                    case Recorrencia.Semanal:
                        recorrencia = "Week";
                        break;
                    case Recorrencia.Mensal:
                        recorrencia = "Month";
                        break;
                    case Recorrencia.Nunca:
                        recorrencia = "";
                        break;
                }

                _frequencia.Add(recorrencia, this.TotalRecorrencia);
                return _frequencia;
            }
        }

    }

    public enum Recorrencia
    {
        Diaria,
        Semanal,
        Mensal,
        Nunca
    }
}
