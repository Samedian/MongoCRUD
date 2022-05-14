using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    public class PersonModel
    {
        //[BsonId]
        public ObjectId _id { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressModel Address { get; set; }



    }
}
