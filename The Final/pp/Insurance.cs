using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp
{
    public class Insurance
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Years_Expire { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        
        public Insurance(int insurance)
        {
            ID = insurance;
            Row row = Access.getObjects(SQL_Queries.Select("insurance", new Condition("id", insurance)))[0];
            Name = row.GetColValue(1).ToString();
            Questions = GetQustions();
            Price = int.Parse(row.GetColValue(2).ToString());
            Years_Expire = int.Parse(row.GetColValue(3).ToString());
            Discount = int.Parse(row.GetColValue(4).ToString());
        }
        public Insurance()
        {

        }
        private List<Question> GetQustions()
        {
            List<Question> list,qustions = new List<Question>();
            string query = SQL_Queries.Select("question", new Condition("insurance_type", ID));
            List<Row> table = Access.getObjects(query);
            if (table == null || table.Count == 0)
                return null;
            foreach(Row row in table)
                qustions.Add( new Question(row));
            list = new List<Question>();
            for(int i = 0; i < qustions.Count;i++)
            {
                foreach(Question row in qustions) {
                    if (row.Order == i)
                    {
                        list.Add(row);
                        break;
                    }
                }
            }
            return list;
        }
        public bool Save()
        {
            List<object> values = new List<object>()
            {
                ID,
                Name,
                Price,
                Years_Expire,
                Discount
            };
            bool execute = Access.Execute(SQL_Queries.Insert("insurance", values));
            foreach (Question q in Questions)
                execute &= q.Save(ID);
            return execute;
        }
        public bool Update()
        {
            List<Col> values = new List<Col>()
            {
                new Col("id",ID),
                new Col("TYPE_NAME",Name),
                new Col("price",Price),
                new Col("expire",Years_Expire),
                new Col("discount",Discount)
            };
            Condition condition = new Condition("id", ID);
            bool execute = Access.Execute(SQL_Queries.Update("insurance", values, condition));
            foreach (Question q in Questions)
                execute &= q.Update(ID);
            return execute;
        }
    }
}
