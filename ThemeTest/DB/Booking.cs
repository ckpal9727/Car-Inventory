using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThemeTest.DB
{
	public class Booking
	{
		[Key]

		public Guid BookingId { get; set; }       // Unique identifier for the booking
		[ForeignKey("Vehicle")]
		public Guid CarId { get; set; }
		[ForeignKey("User")]
		public string UserId { get; set; }          // The ID of the user who made the booking
		public DateTime StartDate { get; set; }  // The start date of the booking period
		public DateTime EndDate { get; set; }    // The end date of the booking period
		public decimal TotalPrice { get; set; }  // The total price for the booking

		// Navigation properties (optional)
		public Vehicle Vehicle { get; set; }             // The car associated with this booking
		public User User { get; set; }           // The user associated with this booking
	}

}
