using System.Runtime.Serialization;

namespace FileManager
{
    [Serializable]
    public class AuthorizationFields
    {
        public string Login { get; set; }
        public string Password { get; set; }

        [OnSerializing]
        public void OnSerializing()
        {
            //
            //
        }

        [OnDeserialized]
        public void OnDeserialized()
        {
            //
            //
        }
    }
}
