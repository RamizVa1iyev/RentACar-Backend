using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;

namespace Core.Utilities.Busniness
{
    public class BusinessRules
    {
        public static IResult Run(List<IResult> logic)
        {
            return logic.FirstOrDefault(l => !l.Success);
        }
    }
}
