using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp
{
    public class Question
    {
        public int Type;
        public int ID;
        public Question_Condition Condition  = new Question_Condition(-1, "אין הגבלה", 0);
        public int Order;
        /*
         * 
         1 open
         2 multi options
         3 date
    
             */
        public string Q;
        public object Answer=null;
        public int index;
        public List<American_Answer> Answers = new List<American_Answer>();
        public Question(){ }
        public Question(Question q) { Copy(q); }
        public void Copy(Question q)
        {
            Type = q.Type;
            ID = q.ID;
            Q = q.Q;
            Answer = q.Answer;
            Order = q.Order;
            index = q.index;
            Answers.Clear();
            foreach(American_Answer a in q.Answers)
                Answers.Add(new American_Answer(a));
            Condition = new Question_Condition(q.Condition);
        }
        public int getDetailIndex()
        {
            for (int i = 0; i < Answers.Count; i++)
                if (Answers[i].Detail)
                    return i;
            return -1;
        }
        public Question(Row row)
        {
            string query;
            List<Row> answers;
            Q = row.GetColValue("question").ToString();
            Type = int.Parse(row.GetColValue("type_question").ToString());
            ID= int.Parse(row.GetColValue("id").ToString());
            Order= int.Parse(row.GetColValue("order_by").ToString());
            query = SQL_Queries.Select("qusetion_condition", new Condition("id_question", ID));
            answers = Access.getObjects(query);
            if (answers != null && answers.Count != 0)
            {
                Condition = new Question_Condition(answers[0]);
            }
            query = SQL_Queries.Select("american_answers", new Condition("question_id" , ID));
            answers = Access.getObjects(query);
            foreach (Row r in answers)
                Answers.Add(new American_Answer(r));
            
        }
        public void SetPrice(int index,int price)
        {
            Answers[index].Price = price;
        }
        public void SetAmericanDetail(int index,bool state)
        {
            foreach (American_Answer a in Answers)
                a.SetDetail(false);
            Answers[index].SetDetail(state);
        }
        public Question(string q,int type)
        {
            Q = q;
            Type = type;
        }
        public void SetAnswer(object ans)
        {
            Answer = ans;
        }
        public Question(string question,List<American_Answer> op)
        {
            Q = question;
            Type = 2;
            Answers = op;
        }
        public bool IsDetail()
        {
            foreach (American_Answer a in Answers)
                if (a.Detail)
                    return true;
            return false;
        }
        public void Remove_American_Answer(int index)
        {
            Answers.RemoveAt(index);
        }
        public void Add_American_Answer(string answer,bool state)
        {
            Answers.Add(new American_Answer(answer, 0));
            SetAmericanDetail(Answers.Count-1,state);
        }
        public bool Update(int insurance)
        {
            List<Col> values = new List<Col>()
            {
                new Col("id",ID),
                new Col("insurance_type",insurance),
                new Col("question",Q),
                new Col("type_question",Type),
                new Col("order_by",Order)
            };
            Condition con = new Condition("id", ID);
            string query = SQL_Queries.Update("question", values, con);
            bool execute = Access.Execute(query);
            switch (Type)
            {
                case 1:
                    return execute&Condition.Update(ID);
                case 2:
                    foreach(American_Answer a in Answers)
                        execute &= a.Update(ID);
                    return execute;
                case 3:
                    return execute & Condition.Update(ID);
                default:
                    return execute;
            }
        }
        public bool Save(int insurance)
        {
            List<object> values = new List<object>()
            {
                utils.getLestId("question")+1,
                insurance,
                Q,
                Type,
                Order
            };
            bool execute = Access.Execute(SQL_Queries.Insert("question", values));
            switch (Type)
            {
                case 1:
                    return execute & Condition.Save(ID);
                case 2:
                    foreach (American_Answer a in Answers)
                        execute &= a.Save(ID);
                    return execute;
                case 3:
                    return execute & Condition.Save(ID);
                default:
                    return execute;
            }

        }

    }
}
