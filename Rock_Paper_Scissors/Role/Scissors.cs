using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors.Role
{
    public class Scissors : RoleRival
    {
        public override bool Attack(Rival rival)
        {
            string roleRival = rival.GetRole();

            switch (roleRival)
            {
                case "Rock":
                    return false;

                case "Paper":
                    return true;

                case "Scissors":
                    return false;
            }

            return false;
        }

        public override string Rest()
        {
            return "I sharpening scissors";
        }

        public override string ToString()
        {
            return "Scissors";
        }
    }
}
