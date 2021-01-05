using Booth.Domain.BoothManagement.ValueObjects;
using Booth.Shared;

namespace Booth.Domain.BoothManagement
{
    public class BoothStaff : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int BoothId { get; private set; }

        public Salary Salary { get; private set; }

        public Phone Phone { get; private set; }

        public Booth Booth { get; private set; }

        public BoothStaff(string firstName,
                          string lastName,
                          Salary salary,
                          Phone phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Phone = phone;
        }

        public void ChangeDetails(string firstName,
                                  string lastName,
                                  Salary salary,
                                  Phone phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Phone = phone;
        }
    }
}
