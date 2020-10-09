using System;
using System.Collections.Generic;
using System.Text;
using Rock_Paper_Scissors.Role;

namespace Rock_Paper_Scissors
{
    public class Rival
    {
        private int HealthPoints = 0;
        private int PowerPoints = 0;
        private int id;

        private RoleRival roleRival;

        public Rival(int id)
        {
            Random randomNumber = new Random();

            this.HealthPoints = randomNumber.Next(1, 11);
            this.PowerPoints = randomNumber.Next(1, 6);

            this.id = id + 1;

            int role = randomNumber.Next(1, 4);

            if(role == 1)
            {
                this.roleRival = new Rock();
            }
            else if(role == 2)
            {
                this.roleRival = new Paper();
            }
            else
            {
                this.roleRival = new Scissors();
            }
            
        }

        public bool AttackRivel(Rival rival)
        {
            return this.roleRival.Attack(rival);
        }

        public string GetRole()
        {
            return this.roleRival.ToString();
        }

        public int GetHealthPoints()
        {
            return this.HealthPoints;
        }

        public int GetPowerPoint()
        {
            return this.PowerPoints;
        }

        public int GetID()
        {
            return this.id;
        }

        public void SetHealthPoints(int point)
        {
            this.HealthPoints += point;
        }

        public void SetPowerPoints(int point)
        {
            this.PowerPoints += point;
        }

        public string SayPhraseAndGoRest()
        {
            if(this.HealthPoints < 10)
            {
                ++this.HealthPoints;
            }

            if(this.PowerPoints < 5)
            {
                ++this.PowerPoints;
            }

            return this.roleRival.Rest();
        }
    }
}
