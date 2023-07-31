namespace Eliseev.RestEase.HttpMessageHendlerDIExample.Client
{
    internal class Incrementator
    {
        private static int increment;

        public int GetNext() => ++increment;
    }
}
