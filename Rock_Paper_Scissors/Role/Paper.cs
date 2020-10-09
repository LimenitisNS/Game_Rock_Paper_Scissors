using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors.Role
{
    public class Paper : RoleRival
    {
        public override bool Attack(Rival rival)
        {
            string roleRival = rival.GetRole();

            switch (roleRival)
            {
                case "Rock":
                    return true;

                case "Paper":
                    return false;

                case "Scissors":
                    return false;
            }

            return false;
        }

        public override string Rest()
        {
            return "I pull out a new leaf";
        }

        public override string ToString()
        {
            return "Paper";
        }
    }
}
