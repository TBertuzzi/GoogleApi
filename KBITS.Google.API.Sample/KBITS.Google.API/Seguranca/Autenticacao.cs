using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using KBITS.Google.API.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KBITS.Google.API.Seguranca
{
    public class Autenticacao
    {
        public string NomeAplicacao { get; set; }
        public string ArquivoJson { get; set; }
        public Permissao Permissao { get; set; }
        public Produto Produto { get; set; }

        internal dynamic Autenticar()
        {
            try
            {
                UserCredential credential;

                string[] Scopes;

                switch (this.Produto)
                {
                    case Produto.Agenda:
                        if (this.Permissao == Permissao.Total)
                            Scopes = new string[] { CalendarService.Scope.Calendar };
                        else
                            Scopes = new string[] { CalendarService.Scope.CalendarReadonly };
                        break;
                    default:
                        Scopes = new string[1];
                        throw new AtutenticacaoException("Produto Não Configurado!");
                }

                using (var stream =
                       new FileStream(this.ArquivoJson, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/" + this.NomeAplicacao + ".json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Criar Google Calendar API service.
                dynamic service;

                switch (this.Produto)
                {
                    case Produto.Agenda:
                        service = new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = this.NomeAplicacao,
                        });
                        break;
                    default:
                        Scopes = new string[1];
                        throw new AtutenticacaoException("Produto Não Configurado!");
                }

                return service;
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
    }

    public enum Permissao
    {
        Leitura,
        Total
    }

    public enum Produto
    {
        Agenda
    }
}
