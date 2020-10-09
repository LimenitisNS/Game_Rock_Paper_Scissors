using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors.Role
{
    public abstract class RoleRival
    {
        public abstract override string ToString();

        public abstract bool Attack(Rival rival);

        public abstract string Rest();
    }
}
