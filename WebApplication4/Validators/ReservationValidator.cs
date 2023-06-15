using FluentValidation;
using WebApplication4.Models;

namespace WebApplication4.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.reservationEnd).GreaterThan(x => x.reservationStart);
        }
    }
}
