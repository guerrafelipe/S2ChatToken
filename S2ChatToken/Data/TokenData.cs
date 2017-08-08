using System.Runtime.Serialization;

namespace S2ChatToken.Data
{
    [DataContract]
    public class TokenData
    {
        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public string client_id { get; set; }

        [DataMember]
        public string access_token { get; set; }

        [DataMember]
        public string expires_at { get; set; }

        [DataMember]
        public int seconds_left { get; set; }
    }
}
