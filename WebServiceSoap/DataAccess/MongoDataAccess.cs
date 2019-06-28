using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WebServiceSoap.DataAccess
{
    public class MongoDataAccess
    {
        private IMongoDatabase CreateConectionMongo() {

            var client = new MongoClient("mongodb+srv://<username>:<password>@<cluster-address>/test");

            return client.GetDatabase("PruebaBd");
        }

        public async void CreateClient(DAOClients Client) {
            IMongoDatabase db = CreateConectionMongo();           

           await db.GetCollection<DAOClients>("Clients").InsertOneAsync(Client);

        }

        public async Task<bool> UpdateClient(DAOClients Client,string UpdateFieldName, string UpdateFieldValue) {

            IMongoDatabase db = CreateConectionMongo();

            var col = db.GetCollection<DAOClients>("Clients");
                        
            var filter = Builders<DAOClients>.Filter.Eq("sharedkey", Client.SharedKey);

            var update = Builders<DAOClients>.Update.Set(UpdateFieldName, UpdateFieldValue);

            var result = await col.UpdateOneAsync(filter, update);

            return result.ModifiedCount != 0;
        }

        public async Task<List<DAOClients>> listClient()
        {
            IMongoDatabase db = CreateConectionMongo();

            return await db.GetCollection<DAOClients>("Clients").Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> DeleteClient(ObjectId SharedKey)
        {
            IMongoDatabase db = CreateConectionMongo();

            var col = db.GetCollection<BsonDocument>("Clients");

            var result = await col.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("SharedKey", SharedKey));

            return result.DeletedCount != 0;
        }

    }
}