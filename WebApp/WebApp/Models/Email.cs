namespace WebApp.Models
{
    public abstract class Email
    {
        public String Address { get; private set; }

        public Email() { }

        public Email(string address)
        {
            this.Address = address;
        }

    }
}
