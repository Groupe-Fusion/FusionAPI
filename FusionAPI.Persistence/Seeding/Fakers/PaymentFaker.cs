using Bogus;
using Bogus.DataSets;
using FusionAPI.Domain.Models;

namespace FusionAPI.Persistence.Seeding.Fakers
{
    public sealed class PaymentFaker : Faker<Payment>
    {
        public PaymentFaker()
        {
            //RuleFor(p => p.PaymentId, f => f.IndexFaker);
            RuleFor(p => p.TotalPrice, f => f.Random.Decimal(1, 1000));
            RuleFor(p => p.DeliveryPrice, f => f.Random.Decimal(1, 100));
            RuleFor(p => p.ServicePrice, f => f.Random.Decimal(1, 100));
            RuleFor(p => p.CardOwner, f => f.Name.FullName());
            RuleFor(p => p.CardNumber, f => f.Finance.CreditCardNumber(CardType.Visa)); // Fixed: Use CardType enum instead of string
            RuleFor(p => p.CardCvc, f => f.Finance.CreditCardCvv());
            RuleFor(p => p.CardExpiry, f => f.Date.Future(1).ToString("MM/yy"));
            RuleFor(p => p.IsSavedForFutureUse, f => f.Random.Bool());
            RuleFor(p => p.FacturationAddress, f => f.Address.StreetAddress());
            RuleFor(p => p.FacturationCity, f => f.Address.City());
            RuleFor(p => p.FacturationPostalCode, f => f.Address.ZipCode());
            RuleFor(p => p.FacturationCountry, f => f.Address.Country());
            RuleFor(p => p.IsPaid, f => f.Random.Bool());
        }
    }
}
