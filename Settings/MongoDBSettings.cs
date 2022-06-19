namespace Catalog_Web_API.Settings
{
    public class MongoDBSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
        public string ConnectionString { 
            get
            {
                return $"mongodb://{User}:{Pwd}@{Host}:{Port}";
            } 
        }
    }
}
