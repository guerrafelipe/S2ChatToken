using S2ChatToken.Data;
using System.IO;
using System.Net;

namespace S2ChatToken
{
    public class TokenApiClient
    {
        #region ::Construtor

        public TokenApiClient(){}

        #endregion

        #region ::Métodos

        /// <summary>
        /// Responsável por retornar o objeto Token.
        /// </summary>
        /// <param name="userName">Nome de usuario</param>
        /// <param name="password">Senha do usuario</param>
        /// <param name="apiBaseUri">URL para requisição. Ex:http://api.s2chat.com.br/api_key/create </param>
        /// <returns>Retorna o objeto TokenData</returns>
        public static TokenData GetToken(string userName, string password, string apiBaseUri)
        {
            WebRequest webRequest = WebRequest.Create(apiBaseUri);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            string postString = "{\"auth\":{\"username\":\"" + userName + "\",\"password\":\"" + password + "\"}}";

            byte[] data = System.Text.Encoding.UTF8.GetBytes(postString);
            using (Stream newStream = webRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            WebResponse response = webRequest.GetResponse();
            using (StreamReader requestReader = new StreamReader(response.GetResponseStream()))
            {
                string webResponse = requestReader.ReadToEnd();
                response.Close();
                return TokenSerializer.JsonToObject<TokenData>(webResponse);
            };
        }

        #endregion
    }
}
