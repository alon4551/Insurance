using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp
{
    public class Question_Condition
    {
        public int ID { get; set; } = -1;
        public int Type { get; set; } = -1;
        /*
         * 0 not null
         * 1 id
         * 2 mobile
         * 3 local
         * 4 email
         * 5 date
        */
        public int Limit { get; set; } = -1;
        public List<Condition_Date> Dates { get; set; } = new List<Condition_Date>();
        public string Message { get; set; } = "";
        public Question_Condition() { }
        public Question_Condition(Question_Condition q)
        {
            ID = q.ID;
            Type = q.Type;
            Limit = q.Limit;
            Message = q.Message;
            foreach (Condition_Date d in q.Dates)
            {
                Dates.Add(new Condition_Date(d));
            }
        }
        public Question_Condition(Row row)
        {
            string query;
            Type = int.Parse(row.GetColValue("condition").ToString());
            ID = int.Parse(row.GetColValue("id_question").ToString());
            if (Type == 5)
            {
                query = SQL_Queries.Select("question_mindate", new Condition("id_question", int.Parse(row.GetColValue(0).ToString())));
                foreach (Row r in Access.getObjects(query))
                    Dates.Add(new Condition_Date(r));
                Limit = Dates[0].Limit;
            }
            Message = row.GetColValue("warning").ToString();
        }
        public Question_Condition(int type, string message, int limit)
        {
            Limit = limit;
            Type = type;
            Message = message;
        }

        public void Remove_Condition(int index)
        {
            Dates.RemoveAt(index);
        }
        public void Add_Condition_Date(int limit, int range, int price)
        {
            Dates.Add(new Condition_Date(limit, range, price));
        }
        public void RemoveDate(int index) { Dates.RemoveAt(index); }
        public void AddDateCondition(int mindate, int range, int price)
        {
            Dates.Add(new Condition_Date(mindate, range, price));
        }
        public void UpdateDateCondition(int index, string mindate, string range, string price)
        {
            Dates[index].Limit = int.Parse(mindate);
            Dates[index].Range = int.Parse(range);
            Dates[index].Price = int.Parse(price);
        }
        public bool Update(int question)
        {
            if (Type == -1) return true;
            if (Type == 5)
                foreach (Condition_Date Date in Dates)
                    if (Date.Update(question) == false || Date.Save(question) == false)
                        return false;
            List<Col> values = new List<Col>()
            {
                new Col("id_question",question),
                new Col("condition",Type),
                new Col("warning",Message)
            };
            return Access.Execute(SQL_Queries.Update("qusetion_condition", values, new Condition("id_question", ID)));
        }
        public bool Save(int question)
        {
            if (Type == -1) return true;
            if (Type == 5)
                foreach (Condition_Date Date in Dates)
                    if (Date.Save(question) == false)
                        return false;
            List<object> values = new List<object>()
            {
              question,
                Type,
                Message
            };
            return Access.Execute(SQL_Queries.Insert("qusetion_condition", values));
        }

    }
}
