using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Interface
{
    public class IProduct
    {
        string Name { get; }
        decimal Price { get; set; }
        int Quantity { get; set; }
    }
}
