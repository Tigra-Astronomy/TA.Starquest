namespace TA.Starquest.BusinessLogic.Preconditions
    {
    static class PreconditionExtensions
        {
        public static bool SatisfiesPrecondition<T>(this T candidate, IPredicate<T> condition)
            {
            return condition.Evaluate(candidate);
            }
        }
    }