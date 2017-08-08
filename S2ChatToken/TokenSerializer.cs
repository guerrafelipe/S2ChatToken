using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace S2ChatToken
{
    public static class TokenSerializer
    {
        /// <summary>
        /// Responsável por retornar o Objeto com base em seu tipo.
        /// </summary>
        /// <typeparam name="T">Tipo do objecto</typeparam>
        /// <param name="json">String json que será deserializa</param>
        /// <returns>Objeto tipo T</returns>
        public static T JsonToObject<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (var tk = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                return (T)serializer.ReadObject(tk);
            }
        }
    }
}
