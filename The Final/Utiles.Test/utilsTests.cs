using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pp;
namespace Utiles.Test
{
   public class utilsTests
    {
        [Theory]
        [InlineData(1,"206517336")]
        [InlineData(1, "209152388")]
        [InlineData(2, "054-761-7157")]
        [InlineData(2, "054-7617157")]
        [InlineData(2, "0547617157")]
        [InlineData(3, "086585685")]
        [InlineData(3, "08-6585685")]
        [InlineData(3, "08-658-5685")]
        [InlineData(4, "alon4551@gmail.com")]
        [InlineData(4, "alon4551@walla.com")]
        public void Check_ShouldValidateInputSecseed(int type,string value)
        {
            Assert.True(utils.Check(type, value));
        }
        [Theory]
        [InlineData(1,"206517335")]
        [InlineData(1, "")]
        [InlineData(1, "206517as")]
        [InlineData(1, "2123151235489123")]
        [InlineData(1, "12345678")]
        [InlineData(2, "054---6585685")]
        [InlineData(2, "054--585685")]
        [InlineData(2, "08658568sdad")]
        [InlineData(2, "08658a2344")]
        [InlineData(3, "05--85685")]
        [InlineData(4, "alon4551gmail.com")]
        [InlineData(4, "")]
        [InlineData(4, "sadknsal")]
        [InlineData(4, "sadknsal.com")]
        [InlineData(4, "sadknsal@com")]
        [InlineData(4, "sadknsal@gmailcom")]
        [InlineData(4, "@gmail.com")]
        public void Check_ShouldValidateInputFail(int type,string value)
        {
            Assert.False(utils.Check(type, value));
        }
        [Theory]
        [InlineData("29/08/1998",18)]
        public void Check_ShouldValidateInputDateSecced(string date,int years)
        {
            Assert.True(utils.Check(date, years));
        }
        [Theory]
        [InlineData("29/08/2010", 18)]
        [InlineData("04/03/1998", 50)]
        [InlineData("0sadas8", 23)]
        [InlineData("", 23)]
        public void Check_ShouldValidateInputDateFail(string date, int years)
        {
            Assert.False(utils.Check(date, years));
        }
    }
}
