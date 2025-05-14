using Bogus;
using FusionAPI.Domain.Models;

namespace FusionAPI.Persistence.Seeding.Fakers
{
    public sealed class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            //RuleFor(u => u.Id, f => f.UniqueIndex);
            RuleFor(u => u.FirstName, f => f.Person.FirstName);
            RuleFor(u => u.LastName, f => f.Person.LastName);
            RuleFor(u => u.Email, f => f.Person.Email);
            RuleFor(u => u.PhoneNumber, f => f.Person.Phone);
            RuleFor(u => u.Password, f => f.Internet.Password());
            RuleFor(u => u.ConfirmPassword, (f, u) => u.Password);
            RuleFor(u => u.AcceptConditions, f => f.Random.Bool(0.5f));
        }
    }
}
