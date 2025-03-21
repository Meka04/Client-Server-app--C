using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.model;

namespace Project.repo
{
    public class ContestRepo: AbstractRepo<int, Contest>
    {
        private readonly IDictionary<int, Contest> items;
        private static readonly ILog log = LogManager.GetLogger("AbstractRepo");

        ContestRepo() { }

        public void add(int id, Contest elem)
        {
            if (elem != null)
            {
                items.Add(id, elem);
                //String type = elem.getType();
                //int particip = elem.getParticipants();

                //string query = @"Insert into Contest(type,participants) Values (type,particip)";

                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText= "Insert into Contest(type,participants) Values (@type,@participants)";

                var paramType = comm.CreateParameter();
                paramType.ParameterName = "@type";
                paramType.Value = elem.getType();
                comm.Parameters.Add(paramType);

                var paramParticipants = comm.CreateParameter();
                paramParticipants.ParameterName = "@participants";
                paramParticipants.Value = elem.getParticipants();
                comm.Parameters.Add(paramParticipants);

                var result = comm.ExecuteNonQuery();
                log.InfoFormat("Adding into repo id {0} with value {1}", id, elem);
            }
            else
                Console.WriteLine("Element cannot be null");
        }

        public void delete(int id, Contest elem)
        {
            if (items.ContainsKey(id))
            {
                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText = "Delete From Contest Where Contest.id = @id";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = elem.getId();
                comm.Parameters.Add(paramId);

           
                var result = comm.ExecuteNonQuery();

       
                log.InfoFormat("Adding into repo id {0} with value {1}", id, elem);
            }
            else
                Console.WriteLine("Element not in list");
        }

        public void update(Contest elem, int id)
        {
            if (items.ContainsKey(id))
            {
                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText = "Update Contest Set Contest.type=@type Contest.participants=@participants where Contest.id=@id";

                var paramType = comm.CreateParameter();
                paramType.ParameterName = "@type";
                paramType.Value = elem.getId();
                comm.Parameters.Add(paramType);

                var paramParticipants = comm.CreateParameter();
                paramParticipants.ParameterName = "@participants";
                paramParticipants.Value = elem.getParticipants();
                comm.Parameters.Add(paramParticipants);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = elem.getId();
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();

                log.InfoFormat("Updated element with new id {0} and value {1}", id, elem);
            }
            else
                Console.WriteLine("Element not found");
        }

    }
}
