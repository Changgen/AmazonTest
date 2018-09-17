using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationTest.Generic.Utils;

namespace AutomationTest.Generic.Asserts
{
    public static class Verify
    {
        private static Collection<Exception> errors = new Collection<Exception>();

        public static Collection<Exception> Errors
        {
            get { return errors; }
        }

        public static bool AreEqual(object expected, object actual)
        {
            CheckPointState<object> checkpoint = new CheckPointState<object>();
            checkpoint.CompareValue += Assert.AreEqual;
            checkpoint.CatchErrors += Errors.Add;
            return checkpoint.Check(expected, actual);
        }

        public static bool IsTrue(bool condition)
        {
            CheckPointState<bool> checkpoint = new CheckPointState<bool>();
            checkpoint.CheckCondition += Assert.IsTrue;
            checkpoint.CatchErrors += Errors.Add;
            return checkpoint.Check(condition);
        }

        public static void That(params Action[] asserts)
        {
            foreach (var assert in asserts)
            {
            }
        }

        public static void That(Action assert, string verifyMessage)
        {
            try
            {
                assert();
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        public static void That(Action assert, string verifyMessage, Action takeScreenshot)
        {
            Log.Trace(verifyMessage);
            try
            {
                assert();
            }
            catch(Exception ex)
            {
                takeScreenshot();
                errors.Add(ex);
            }
        }
    }
}
