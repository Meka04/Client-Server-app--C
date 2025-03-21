using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.model
{
    public class Contest
    {
        private String type;
        private int participants;
        private int id;

        public Contest(String type, int participants, int id)
        {
            this.type = type;
            this.participants = participants;
            this.id = id;
        }

        public int getParticipants() { return this.participants; }
        public String getType() { return this.type; }
        public int getId() { return this.id; }

        public void SetParticipants(int newNumber)
        {
            if (newNumber >= 0)
                this.participants = newNumber;
        }
        public void setType(String newType)
        {
            String[] types = { "drawing", "treasure hunt", "poetry" };
            //bool ok = Arrays.asList(types).contains(newType);  -> functional but in C#
            //if (ok)
                this.type = newType;
        }

    }
}
