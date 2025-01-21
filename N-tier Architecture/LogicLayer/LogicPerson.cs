using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
namespace LogicLayer
{
    public class LogicPerson
    {
        public static List<EntityPerson> LLpersonList()
        {
            return DALPerson.PersonList();
        }
        public static int LLpersonAdd(EntityPerson p)
        {
            if (p.Name != null && p.Surname != null
                && p.Salary > 5000 && p.Job != null
                && p.City != null

                )
            {
                return DALPerson.personAdd(p);
            }

            else
            {
                return -1;
            }

        }
        public static int LLpersonupdate(EntityPerson p)
        {
            if (p.Name != null && p.Surname != null
                && p.Salary > 5000 && p.Job != null
                && p.City != null
                && p.Id>=1
                )
            {
                return DALPerson.personupdate(p);
            }

            else
            {
                return -1;
            }

        }
        public static bool LLpersonDelete(int i)
        {
            if(i>=1)
            {
                return DALPerson.personDelete(i);
            }
            else
            {
                return false;
            }
        }
    }
}
