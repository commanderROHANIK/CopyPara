using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Patients
{
    public enum Condition
    {
        Walking,
        Wheelchair,
        Disabled
    }

    public static class ConditionExtensions
    {
        public static bool IsDisabled(this Condition condition)
        {
            return condition == Condition.Wheelchair 
                || condition == Condition.Disabled;
        }
    }
}
