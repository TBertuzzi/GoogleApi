using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBITS.Google.API.About
{
    public class Sobre
    {
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public List<string> Funcionalidades { get; set; }
        public string Versao { get; set; }

    }

    public class SobreAPI
    {
        public Sobre obterInformacoesCalendario()
        {
            Sobre retorno = new Sobre();

            retorno.Autor = "Thiago Bertuzzi";
            retorno.Descricao = "Classe Responsavel pelas Funcionalidades com o Google Calendar";

            List<string> funcionalidades = new List<string>();
            funcionalidades.Add("Listar Calendarios");
            funcionalidades.Add("Listar Eventos");
            funcionalidades.Add("Inserir Eventos");
            funcionalidades.Add("Inserir Eventos com recorrencia");

            retorno.Funcionalidades = funcionalidades;
            retorno.Versao = "1.0.0.0";

            return retorno;
        }
    }
}
