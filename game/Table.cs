using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace game
{
    class Table
    {
        private ConsoleTable table;

        public Table(string[][] array) 
        {
            table=Create(array);
        }



        private ConsoleTable Create(string[][] array)
        {
            array[0][0] = "PC\\User";
            ConsoleTable newTable = new ConsoleTable(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                newTable.AddRow(array[i]);
            }
            return newTable;
        }

        public override string ToString()
        {
            return table.ToStringAlternative();
        }
    }
}
