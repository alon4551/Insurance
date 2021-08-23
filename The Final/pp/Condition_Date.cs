using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp
{
    public class Condition_Date 
    {
        public int ID { get; set; } = -1;
        public int Limit { get; set; } = 0;
        public int Range { get; set; } = -1;
        public int Price { get; set; } = 0;
        public Condition_Date(Condition_Date d) 
        {
            ID = d.ID;
            Limit = d.Limit;
            Range = d.Range;
            Price = d.Price;
        }
        public Condition_Date(int limit,int range,int price){

            Limit = limit;
            Range = range;
            Price = price;
        }
        public Condition_Date(Row row)
        {
            ID= int.Parse(row.GetColValue(0).ToString());
            Limit = int.Parse(row.GetColValue("years").ToString());
            Range = int.Parse(row.GetColValue("range").ToString());
            Price = int.Parse(row.GetColValue("price").ToString());
        }
        public bool Update(int id_question)
        {
            List<Col> values = new List<Col>()
            {
                new Col("id",ID),
                new Col("id_question",id_question),
                new Col("years",Limit),
                new Col("range",Range),
                new Col("price",Price)
            };
            Condition condition = new Condition("id", ID);
            return Access.Execute(SQL_Queries.Update("question_mindate", values, condition));
        }
        public bool Save(int id_question)
        {
            if (ID == -1)
                ID = utils.getLestId("question_mindate") +1;
            List<object> values = new List<object>()
            {
                ID,
                id_question,
                Limit,
                Range,
                Price
            };
            return Access.Execute(SQL_Queries.Insert("question_mindate", values));
        }
    }
}
