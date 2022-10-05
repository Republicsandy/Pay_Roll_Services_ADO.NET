using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay_Roll_Services_ADO
{
    public class EmployeePayRoll
    {
            public int EmployeeId { get; set; }
            public int Phone { get; set;  }
            public double BasicPay { get; set; }
            public string Address { get; set;  }
            public string Name { get; set;  }
            public string Department { get; set; }
            public string Gender{ get; set; }
            public DateTime StartDate { get; set; }
            public double TaxblePay  { get; set; }
            public double NetPay  { get; set; }
            public double Number { get; set; }
            public double IncomeTax { get; set; }
            public double Deductions { get; set; }
    }
}
