using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace MongoDB
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            MongoDbCrud db = new MongoDbCrud("AddressBook");

            PersonModel person = new PersonModel
            {
                FirstName = "Samarth23",
                LastName = "Goel",
                Address = new AddressModel
                {
                    Street = "Naveen Nagar",
                    City = "Moradabad",
                    State = "Uttar Pradesh",
                    ZipCode = "244001"

                }
            };
            db.InsertRecord("Users", person);

            List<PersonModel> records = db.LoadRecords<PersonModel>("Users");

            foreach (var data in records)
            {
                Console.WriteLine($"Id :{ data._id} \nFirst Name:{data.FirstName} \nLast Name:{data.LastName}");

                if (data.Address != null)
                {
                    Console.WriteLine("City :" + data.Address.City);
                }
            }


            PersonModel item = db.LoadRecordById<PersonModel>("Users", ObjectId.Parse("5ffc21ea521d4615bac43faf"));
            Console.WriteLine($"Id :{ item._id} \nFirst Name:{item.FirstName} \nLast Name:{item.LastName}");



            //db.UpdateRecord<PersonModel>("Users", ObjectId.Parse("5ff6c0d30b77882e2228a69c"), person);
            //PersonModel item = db.LoadRecordById<PersonModel>("Users", ObjectId.Parse("5ff6c0d30b77882e2228a69c"));
            //Console.WriteLine($"Id :{ item._id} \nFirst Name:{item.FirstName} \nLast Name:{item.LastName}");

            db.DeleteRecord<PersonModel>("Users", ObjectId.Parse("5ffc21ea521d4615bac43faf"));

            Console.ReadLine();
        }
    }

}
