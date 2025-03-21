using log4net;
using Project.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.repo
{
    class ParticipantRepo : AbstractRepo<int, Participant>
    {
        private readonly IDictionary<int, Participant> items;
        private static readonly ILog log = LogManager.GetLogger("AbstractRepo");

        ParticipantRepo() { }

        public void add(int id, Participant elem)
        {
            if (elem != null)
            {
                items.Add(id, elem);

                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText = "Insert into Participant(name,surname,age) Values (@name,@surname,@age)";

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = elem.getName();
                comm.Parameters.Add(paramName);

                var paramSurname = comm.CreateParameter();
                paramSurname.ParameterName = "@surname";
                paramSurname.Value = elem.getSurname();
                comm.Parameters.Add(paramSurname);

                var paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@age";
                paramAge.Value = elem.getAge();
                comm.Parameters.Add(paramAge);

                var result = comm.ExecuteNonQuery();
                log.InfoFormat("Adding into repo id {0} with value {1}", id, elem);
            }
            else
                Console.WriteLine("Element cannot be null");
        }

        public void delete(int id, Participant elem)
        {
            if (items.ContainsKey(id))
            {
                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText = "Delete From Participant Where Participant.id = @id";

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

        public void update(Participant elem, int id)
        {
            if (items.ContainsKey(id))
            {
                DBConnection connection = new DBConnection();
                var con = connection.getConnection();
                using var comm = con.CreateCommand();
                comm.CommandText = "Update Participant Set Participant.name=@name Participant.surname=@surname Participant.age=@age where Participant.id=@id";

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = elem.getName();
                comm.Parameters.Add(paramName);

                var paramSurname = comm.CreateParameter();
                paramSurname.ParameterName = "@surname";
                paramSurname.Value = elem.getSurname();
                comm.Parameters.Add(paramSurname);

                var paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@age";
                paramAge.Value = elem.getAge();
                comm.Parameters.Add(paramAge);

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
}
