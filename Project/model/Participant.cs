using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.model
{
    class Participant
    {
        String name;
        String surname;
        int age;
        int id;

        public Participant(String name, String surname, int age, int id)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.id = id;
        }
        public Participant() { }

        public String getName() { return this.name; }
        public String getSurname() { return this.surname; }
        public int getAge() { return age; }
        public int getId() { return this.id; }

        public void setName(String name) { this.name = name; }
        public void setSurname(String surname) { this.surname = surname; }
        public void setAge(int age) { this.age = age; }
        public void setId(int id) { this.id = id; }

    }
}
