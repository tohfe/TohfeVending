using System.Collections.Generic;

namespace TohfeVending.Model
{
    public class Services
    {
        public static VendingMachine GetMachine() => VendingMachine.Instance;

        public static List<UserData> GetUsers()
        {
            return new List<UserData>(new UserData[]
            {
                new UserData{UserName = "AAA",Avatar="Default" },
                new UserData{UserName = "BBB",Avatar="Default" },
                new UserData{UserName = "CCC",Avatar="Default" },
                new UserData{UserName = "DDD",Avatar="Default" },
                new UserData{UserName = "EEE",Avatar="Default" },
            });
        }
    }
}
