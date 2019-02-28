using SlackTeam.LIB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTeam.LIB.Provider
{
    public class RDBMBaseProvider
    {
        public RDBMDBContext db = null;
        public RDBMBaseProvider()
        {
            db = new RDBMDBContext();
        }
    }
}
