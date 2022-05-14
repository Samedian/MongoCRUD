using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    public class MongoDbCrud
    {
        private IMongoDatabase db;

        public MongoDbCrud(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table,T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table,ObjectId id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("_id", id);

            return collection.Find(filter).First();
        }

        //public void UpdateRecord<T>(string table, ObjectId id, T record)
        //{
        //    var collection = db.GetCollection<T>(table);
        //    var filter = Builders<T>.Filter.Eq("_id", id);

        //    var result = collection.ReplaceOneAsync(filter, record);

        //}

        public void DeleteRecord<T>(string table,ObjectId id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);

            collection.DeleteOne(filter);

        }

    }
}
