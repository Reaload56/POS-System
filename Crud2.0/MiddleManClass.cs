using Crud2._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    // this is a global helper class for passing values to and from forms
    internal class MiddleManClass
    {
        private static string User;
        private static bool Role;
        private static int Id;
        private static PoS poS;

        //sets user information
        public static void SetUser(string user, int id, bool role)
        {
            User = user;
            Id = id;
            Role = role;
        }

        public static string GetUser(){  return User; } //returns the user name
        public static bool GetRole(){ return Role; } //returns the user's role
        public static int GetId() { return Id; } //returns the user's id

        public static void SetSaleInfo(PoS posInfo)
        {
            poS = posInfo;// loads poS object with point of sale data
        }

        public static PoS GetSaleInfo()  { return poS; }
    }
}
