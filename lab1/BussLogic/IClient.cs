using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussLogic
{
    public interface IClient
    {
        string create_url();
        IEnumerable<Foursquare.Venue> get_json();
        string get_info(IEnumerable<Foursquare.Venue> list, bool test = false);
    }
}
