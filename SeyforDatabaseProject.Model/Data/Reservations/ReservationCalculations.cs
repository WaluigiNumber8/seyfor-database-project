namespace SeyforDatabaseProject.Model.Data.Reservations
{
    public static class ReservationCalculations
    {
        /// <summary>
        /// Calculates reservation total price.
        /// </summary>
        /// <param name="dateStart">Starting date of reservation.</param>
        /// <param name="dateEnd">Ending date of reservation.</param>
        /// <param name="room">Room of the reservation.</param>
        public static decimal CalculatePrice(DateTime dateStart, DateTime dateEnd, RoomItem room)
        {
            int days = (dateEnd - dateStart).Days;
            decimal newPrice = days * room.PricePerNight;
            return newPrice;
        }
    }
}