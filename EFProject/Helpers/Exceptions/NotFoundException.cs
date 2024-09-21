namespace EFProject.Helpers.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base("Not Found Exception") { }

    }
}
