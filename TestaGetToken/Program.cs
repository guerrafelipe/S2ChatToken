using System;
using S2ChatToken;
using S2ChatToken.Data;
using System.Configuration;

namespace TestaGetToken
{
    class Program
    {
        #region ::Propriedades

        // Chave no App.config. 
        // Caso coloque no Web.config por questões de segurança seria interessante criptografar o mesmo. Detalhes: https://msdn.microsoft.com/pt-br/library/dtkwfdky(v=vs.100).aspx
        private static string userName = ConfigurationManager.AppSettings["userName"];
        private static string password = ConfigurationManager.AppSettings["password"];
        private static string apiBaseUri = ConfigurationManager.AppSettings["apiBaseUri"];

        #endregion

        #region ::Métodos

        private static void TestaGetToken()
        {
            string stToken = string.Empty;
            var stopwatch = new System.Diagnostics.Stopwatch();
            Console.Write("Aguarde...");

            try
            {
                stopwatch.Start();
                TokenData objToken = TokenApiClient.GetToken(userName, password, apiBaseUri);
                stopwatch.Stop();

                stToken = string.Format("client_id = {0}{5}access_token = {1}{5}expires_at = {2}{5}seconds_left = {3}{5}success = {4}",
                    objToken.client_id, objToken.access_token, objToken.expires_at, objToken.seconds_left, objToken.success, Environment.NewLine);
            }
            catch (Exception ex)
            {
                stToken = ex.Message;
            }

            Console.Clear();
            Console.WriteLine(stToken);
            Console.WriteLine();
            Console.WriteLine($"Tempo de execução do método GetToken: {stopwatch.Elapsed}");
            stopwatch.Restart();
        }

        static void Main(string[] args)
        {
            bool continuaTeste = false;

            do
            {
                TestaGetToken();
                Console.WriteLine("Deseja testar novamente (S/N)?");
                string retorno = Console.ReadLine();

                continuaTeste = !string.IsNullOrWhiteSpace(retorno) && retorno[0].ToString().ToUpper() == "S";
            } while (continuaTeste);
        }

        #endregion
    }
}
