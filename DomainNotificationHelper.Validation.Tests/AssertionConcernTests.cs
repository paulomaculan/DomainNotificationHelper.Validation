using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainNotificationHelper.Validation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AssertRegexIsValid()
        {
            var emailRegex =
               @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            var res = AssertionConcern.AssertRegexMatch("andrebaltieri@hotmail.com", emailRegex, "E-mail inválido");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertRegexIsInvalid()
        {
            var emailRegex =
               @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            var res = AssertionConcern.AssertRegexMatch("andrebaltieri[at]hotmail[dot]com", emailRegex, "E-mail inválido");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void AssertEmailIsValid()
        {
            var res = AssertionConcern.AssertEmailIsValid("andrebaltieri@hotmail.com", "E-mail inválido");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertEmailIsInvalid()
        {
            var res = AssertionConcern.AssertEmailIsValid("andrebaltieri[at]hotmail[dot]com", "E-mail inválido");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void AssertUrlIsValid()
        {
            var res = AssertionConcern.AssertUrlIsValid("http://andrebaltieri.net/", "URL inválida");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertUrlIsInvalid()
        {
            var res = AssertionConcern.AssertUrlIsValid("agá tê tê pê dois pontos barra barra andrebaltieri.net", "URL inválido");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void AssertIsNull()
        {
            var res = AssertionConcern.AssertIsNull(DateTime.Now, "Well... it is not null!");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void AssertDateIsEqualThan()
        {
            DateTime date = DateTime.Now;
            var res = AssertionConcern.AssertDateIsEqualThan(date, date, "date1 is not equal date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsNotEqualThan()
        {
            var res = AssertionConcern.AssertDateIsNotEqualThan(DateTime.Parse("2200-12-31"), DateTime.Now, "date1 is equal date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsAfterThan()
        {
            var res = AssertionConcern.AssertDateIsAfterThan(DateTime.Parse("2200-12-31"), DateTime.Now, "date1 is not after date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsAfterOrEqualThan_After()
        {
            var res = AssertionConcern.AssertDateIsAfterOrEqualThan(DateTime.Parse("2200-12-31"), DateTime.Now, "date1 is not after or equal date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsAfterOrEqualThan_Equal()
        {
            DateTime data = DateTime.Now;
            var res = AssertionConcern.AssertDateIsAfterOrEqualThan(data, data, "date1 is not after or equal date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsBeforeThan()
        {
            var res = AssertionConcern.AssertDateIsBeforeThan(DateTime.Now, DateTime.Parse("2200-12-31"), "date1 is not before date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsBeforeOrEqualThan_Before()
        {
            var res = AssertionConcern.AssertDateIsBeforeOrEqualThan(DateTime.Now, DateTime.Parse("2200-12-31"), "date1 is not before or equal date 2");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AssertDateIsBeforeOrEqualThan_Equal()
        {
            DateTime data = DateTime.Now;
            var res = AssertionConcern.AssertDateIsBeforeOrEqualThan(data, data, "date1 is not before or equal date 2");
            Assert.IsNull(res);
        }
    }
}