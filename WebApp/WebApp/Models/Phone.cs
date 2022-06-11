namespace WebApp.Models
{
    public abstract class Phone
    {
        public String PhoneNumber { get; private set; }

        public Phone() { }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
