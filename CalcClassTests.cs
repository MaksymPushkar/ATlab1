using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcClassBr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CalcClassBrTests;

namespace CalcClassBr.Tests
{
    [TestClass()]
    public class CalcClassTests
    {
        DataBase dataBase = new DataBase();

        [TestMethod()]
        public void AddTest()
        {
            //arrange
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            dataBase.openConnection();

            string querystring = $"SELECT [id], [a], [b], [expected] FROM[CalcClassTests].[dbo].[AddTest]";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int[] actual = new int[table.Rows.Count];
            int[] expected = new int[table.Rows.Count];

            //act
            for (int i = 0; i < table.Rows.Count; i++)
            {
                actual[i] = CalcClass.Add((int)table.Rows[i][1], (int)table.Rows[i][2]);
                expected[i] = (int)table.Rows[i][3];
            }


            //assert
            Assert.AreEqual(true, actual.SequenceEqual(expected));
        }
    }
}