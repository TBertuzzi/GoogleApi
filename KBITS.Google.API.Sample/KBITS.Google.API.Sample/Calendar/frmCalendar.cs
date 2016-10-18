using KBITS.Google.API.About;
using KBITS.Google.API.Calendar;
using KBITS.Google.API.Seguranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBITS.Google.API.Sample.Calendar
{
    public partial class frmCalendar : Form
    {
        public frmCalendar()
        {
            InitializeComponent();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            SobreAPI sobreAPI = new SobreAPI();
            Sobre sobre = sobreAPI.obterInformacoesCalendario();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Autor: " + sobre.Autor);
            sb.AppendLine("Descrição: " + sobre.Descricao);
            sb.AppendLine("Versão: " + sobre.Versao);
            sb.AppendLine("" );
            sb.AppendLine("Funcionalidades:");
            sb.AppendLine("");
            for (int i = 0; i < sobre.Funcionalidades.Count; i++)
            {
                sb.AppendLine(sobre.Funcionalidades[i]);
            }

            MessageBox.Show(sb.ToString(), "Sobre",  MessageBoxButtons.OK
                , MessageBoxIcon.Information);

        }

        private void btnListarEventos_Click(object sender, EventArgs e)
        {
            Autenticacao autenticacao = new Autenticacao();
            autenticacao.ArquivoJson = "client_secret.json";
            autenticacao.NomeAplicacao = "KBIT Exemplo";
            autenticacao.Permissao = Permissao.Total;
            autenticacao.Produto = Produto.Agenda;

            GoogleAgenda googleAgenda = new GoogleAgenda(autenticacao);

            Calendario calendario = new Calendario();
            calendario.Id = "primary";
            List<Evento> eventos = googleAgenda.ListarEventos(calendario);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("EVENTOS: ");
            sb.AppendLine("");

            foreach (Evento evento in eventos)
            {
                sb.AppendLine( "TITULO: " + evento.Titulo);
            }

            MessageBox.Show(sb.ToString(), "Eventos", MessageBoxButtons.OK
             , MessageBoxIcon.Information);
        }

        private void btnListarcalendarios_Click(object sender, EventArgs e)
        {
            Autenticacao autenticacao = new Autenticacao();
            autenticacao.ArquivoJson = "client_secret.json";
            autenticacao.NomeAplicacao = "KBIT Exemplo";
            autenticacao.Permissao = Permissao.Total;
            autenticacao.Produto = Produto.Agenda;

            GoogleAgenda googleAgenda = new GoogleAgenda(autenticacao);

            List<Calendario> calendarios = googleAgenda.ListarCalendarios();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CALENDARIOS: ");
            sb.AppendLine("");

            foreach (Calendario calendario in calendarios)
            {
                if (!string.IsNullOrEmpty(calendario.Descricao))
                    sb.AppendLine("Descrição: " + calendario.Descricao);
            }

            MessageBox.Show(sb.ToString(), "Calendarios", MessageBoxButtons.OK
           , MessageBoxIcon.Information);

        }

        private void btnInserriEvento_Click(object sender, EventArgs e)
        {
            Autenticacao autenticacao = new Autenticacao();
            autenticacao.ArquivoJson = "client_secret.json";
            autenticacao.NomeAplicacao = "KBIT Exemplo";
            autenticacao.Permissao = Permissao.Total;
            autenticacao.Produto = Produto.Agenda;

            GoogleAgenda googleAgenda = new GoogleAgenda(autenticacao);

            Calendario calendario = new Calendario();
            calendario.Id = "primary";

            Evento evento = new Evento();
            evento.Titulo = "EXEMPLO DE EVENTO";
            evento.Descricao = "EXEMPLO UTILIZANDO A KBITS.GOOGLE.API";
            evento.DataInicial = DateTime.Now;
            evento.DataFinal = DateTime.Now;

            googleAgenda.InserirEvento(evento, calendario);

            MessageBox.Show("Evento Cadastrado no dia : "+ DateTime.Now + " no calendario padrão", "Evento Cadastrado", MessageBoxButtons.OK
         , MessageBoxIcon.Information);
        }
    }
}
