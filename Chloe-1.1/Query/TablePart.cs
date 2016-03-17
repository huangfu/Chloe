﻿using Chloe.Query.DbExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chloe.Query
{
    public class TablePart
    {
        const string prefix = "T";
        public TablePart(DbTableExpression table)
        {
            this.Table = table;
            this.JoinTables = new List<JoinTablePart>();
        }
        public DbTableExpression Table { get; set; }

        public List<JoinTablePart> JoinTables { get; set; }


        internal void SetTableNameByNumber(int num)
        {
            this.Table.Alias = prefix + num.ToString();

            if (this.JoinTables != null)
                foreach (TablePart tablePart in this.JoinTables)
                {
                    tablePart.SetTableNameByNumber(++num);
                }
        }
    }
}
