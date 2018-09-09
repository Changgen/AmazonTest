using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationTest.Generic.Utils;

namespace AutomationTest.Generic.Asserts
{
    public class CheckPointState<T>
    {
        public event Action<T, T> CompareValue;
        public event Action<T> CheckCondition;
        public event Action<Exception> CatchErrors;

        public bool Check(T arg1, T arg2)
        {
            if (this.CompareValue == null)
            {
                throw new NullReferenceException(this.CompareValue.ToString());
            }

            try
            {
                this.CompareValue(arg1, arg2);
                return true;
            }
            catch (Exception ex)
            {
                Log.Trace(ex.ToString());
                this.CatchErrors(ex);
                //Assert.Fail();
                return false;
            }
        }

        public bool Check(T condition)
        {
            Log.Trace("====Check " + condition.ToString());
            try
            {
                this.CheckCondition(condition);
                return true;
            }
            catch (Exception ex)
            {
                Log.Trace(ex.ToString());
                this.CatchErrors(ex);
                Verify.Errors.Add(ex);
                return false;
            }

        }

    }
}
