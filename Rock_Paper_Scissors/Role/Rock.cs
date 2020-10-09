using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors.Role
{
    public class Rock : RoleRival
    {
        public override bool Attack(Rival rival)
        {
            string roleRival = rival.GetRole();

            switch (roleRival)
            {
                case "Rock":
                    return false;

                case "Paper":
                    return false;

                case "Scissors":
                    return true;
            }

            return false;
        }

        public override string Rest()
        {
            return "I glue the stone fragments together";
        }

        public override string ToString()
        {
            return "Rock";
        }
    }
}
