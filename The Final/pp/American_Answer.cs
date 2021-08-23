using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp
{
    public class American_Answer
    {
        public string Answer { get; set; }
        public int ID { get; set; } = -1;
        public int Price { get; set; }
        public bool Detail { get; set; }
        public American_Answer(){ }
        public American_Answer(American_Answer a)
        {
            ID = a.ID;
            Price = a.Price;
            Detail = a.Detail;
            Answer = a.Answer;
        }
        public American_Answer(string answer,int price)
        {
            Answer = answer;
            Price = price;
        }
        public void SetDetail(bool state)
        {
            Detail = state;
        }
        public American_Answer(Row row)
        {
            ID = int.Parse(row.GetColValue("id").ToString());
            Answer = row.GetColValue("answer").ToString();
            Price = int.Parse(row.GetColValue("price").ToString());
            Detail = bool.Parse(row.GetColValue("detail").ToString());
        }
        public bool Update(int id_question)
        {
            List<Col> values = new List<Col>()
            {
                new Col("id",ID),
                new Col("question_id",id_question),
                new Col("answer",Answer),
                new Col("detail",Detail),
                new Col("price",Price)
            };
            Condition condition = new Condition("id", ID);
            return Access.Execute(SQL_Queries.Update("american_answers", values, condition));
        }
        public bool Save(int id_question)
        {
            if (ID == -1) ID = utils.getLestId("american_answers") + 1;
            List<object> values = new List<object>()
            {
                ID,
                id_question,
                Answer,
                Detail,
                Price
            };
            return Access.Execute(SQL_Queries.Insert("american_answers", values));
        }
    }
}
