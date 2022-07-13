namespace Alka.Collections.Models
{
    public interface IPerson : IComparable<IPerson>
    {
        void setId(int Id);
        int getId();
        String getFirstName();
        String getLastName();
        DateOnly getDateOfBirth();
        int getHeight();
    }
}
