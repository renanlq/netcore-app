namespace StoreOfBuild.Domain
{
    public class DomainException : System.Exception
    {
        public DomainException(string error) : base(error)
        {}

        public static void When(bool valid, string error)
        {
            if(!valid)
                throw new DomainException(error);
        }
    }
}