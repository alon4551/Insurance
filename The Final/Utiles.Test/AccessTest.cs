using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using pp;
using System.Threading.Tasks;

namespace Utiles.Test
{
    public class AccessTest
    {
        [Theory]
        [InlineData("test", @"D:\download\up.png")]
        public void InsertImage(string table,string address)
        {
            string query = SQL_Queries.Insert(table, new List<object>() { 0, "@file" });
            //query = ''
            Assert.True(Access.Execute(query,address));
        }
        [Theory]
        [ClassData(typeof(Condition_Date))]
        public void InsertConditionDate(Condition_Date date) 
        {

        }
        public void InsertCondition(Condition condition) 
        {

        }
        public void InsertAnswer(American_Answer answer) { 
        
        }
        public void InsertQustion(Question question) { 

        }
        public void InsertInsurance(Insurance insurance) 
        {

        }
    }
}
