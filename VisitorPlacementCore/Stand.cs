using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Stand
    {
        public List<Row> Rows {  get; set; } = [];
        public string Letter { get; set; }

        public Stand(int rowsAmount, int lenght)
        {
            
            for(int i = 1;  i <= rowsAmount; i++)
            {
                Row row = new(lenght);
                {
                    row.Code = i.ToString();
                }
                Rows.Add(row);
            }
        }
    }
}
