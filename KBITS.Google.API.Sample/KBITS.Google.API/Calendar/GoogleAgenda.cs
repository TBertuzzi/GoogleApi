using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using KBITS.Google.API.Exceptions;
using KBITS.Google.API.Seguranca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KBITS.Google.API.About;

namespace KBITS.Google.API.Calendar
{
    public class GoogleAgenda
    {
        private Autenticacao _Autenticacao { get; set; }

        /// <summary>
        /// Construtor Responsavel por receber o objeto de autenticação.
        /// </summary>
        /// <param name="autenticacao">Objeto de Autenticação</param>
        public GoogleAgenda(Autenticacao autenticacao)
        {
            try
            {
                if (autenticacao.Produto != Produto.Agenda)
                    throw new AtutenticacaoException("Produto Incorreto!");

                if (string.IsNullOrEmpty(autenticacao.ArquivoJson))
                    throw new AtutenticacaoException("ArquivoJson Obrigatorio!");

                if (string.IsNullOrEmpty(autenticacao.NomeAplicacao))
                    throw new AtutenticacaoException("NomeAplicacao Obrigatorio!");

                _Autenticacao = autenticacao;

            }
            catch (AtutenticacaoException aex)
            {
                throw new AtutenticacaoException(aex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna Todos os Calendarios Disponiveis para Sua Conta
        /// </summary>
        /// <returns>Lista de Calendarios</returns>
        public List<Calendario> ListarCalendarios()
        {
            try
            {
                List<Calendario> retorno = new List<Calendario>();
                Calendario calendario;

                CalendarService service = _Autenticacao.Autenticar();
                CalendarListResource.ListRequest lista = service.CalendarList.List();
                CalendarList clist = lista.Execute();

                for (int i = 0; i < clist.Items.Count; i++)
                {
                    calendario = new Calendario();
                    calendario.Id = clist.Items[i].Id;
                    calendario.Nome = clist.Items[i].Summary;
                    calendario.Descricao = clist.Items[i].Description;
                    retorno.Add(calendario);
                }


                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna Todos os eventos de um determinado calendario
        /// </summary>
        /// <param name="calendario">Calendario que Deseja Obter os Eventos</param>
        /// <returns>Lista de Eventos</returns>
        public List<Evento> ListarEventos(Calendario calendario)
        {
            try
            {
                List<Evento> retorno = new List<Calendar.Evento>();
                Evento evento;

                CalendarService service = _Autenticacao.Autenticar();

                // Define os parametros da Requisição
                EventsResource.ListRequest request = service.Events.List(calendario.Id);
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = request.Execute();
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        evento = new Calendar.Evento();
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }

                        evento.DataInicial = Convert.ToDateTime(when.ToString());

                        string whenEnd = eventItem.End.DateTime.ToString();
                        if (String.IsNullOrEmpty(whenEnd))
                        {
                            whenEnd = eventItem.End.Date;
                        }

                        evento.DataFinal = Convert.ToDateTime(whenEnd.ToString());

                        evento.Descricao = eventItem.Description;
                        evento.Localizacao = eventItem.Location;
                        evento.Titulo = eventItem.Summary;
                        retorno.Add(evento);
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inclui um Evento em um Calendario
        /// </summary>
        /// <param name="evento">Evento que deve ser inserido</param>
        /// <param name="calendario">Calendario que deseja inerir o evento</param>
        public void InserirEvento(Evento evento, Calendario calendario)
        {
            try
            {
                //Adicionar Eventos

                Event eventGoogle = new Event();
                eventGoogle.Summary = evento.Titulo;// "Google I/O 2015";
                eventGoogle.Location = evento.Localizacao;// "800 Howard St., San Francisco, CA 94103";
                eventGoogle.Description = evento.Descricao; // "A chance to hear more about Google's developer products.";

                DateTime dataInicial = new DateTime(evento.DataInicial.Year, evento.DataInicial.Month, evento.DataInicial.Day,
                    evento.DataInicial.Hour, evento.DataInicial.Minute, evento.DataInicial.Second, evento.DataInicial.Millisecond);

                EventDateTime start = new EventDateTime();
                start.DateTime = dataInicial;
                start.TimeZone = "America/Sao_Paulo";// "America/Los_Angeles";
                eventGoogle.Start = start;

                DateTime endDateTime = new DateTime(evento.DataFinal.Year, evento.DataFinal.Month, evento.DataFinal.Day,
                 evento.DataFinal.Hour, evento.DataFinal.Minute, evento.DataFinal.Second, evento.DataFinal.Millisecond);

                EventDateTime end = new EventDateTime();
                end.DateTime = endDateTime;
                end.TimeZone = "America/Sao_Paulo";
                eventGoogle.End = end;

                KeyValuePair<string, int> valor = evento.Frequencia.FirstOrDefault();

                if (valor.Key.Trim() == "")
                {
                    List<string> recurrence = new List<string>() { "RRULE:FREQ=" + valor.Key + ";COUNT=" + valor.Value.ToString() + "" };
                    eventGoogle.Recurrence = recurrence;
                }

                //  events2.ate

                //        EventAttendee []
                //        attendees = new EventAttendee[] {
                //    new EventAttendee().setEmail("lpage@example.com"),
                //    new EventAttendee().setEmail("sbrin@example.com"),
                //};
                //    event.setAttendees(Arrays.asList(attendees));

                //events2.

                // Event.RemindersData

                //    EventReminder []
                //    reminderOverrides = new EventReminder[] {
                //    new EventReminder().Method("email").setMinutes(24 * 60),
                //    new EventReminder().Method("popup").setMinutes(10),
                //};
                //Event.Reminders reminders = new Event.Reminders()
                //    .setUseDefault(false)
                //    .setOverrides(Arrays.asList(reminderOverrides));
                //event.setReminders(reminders);

                CalendarService service = _Autenticacao.Autenticar();
                eventGoogle = service.Events.Insert(eventGoogle, calendario.Id).Execute();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

    }
}
