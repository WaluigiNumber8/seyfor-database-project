using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Converts Data Transfer Objects (DTOs) to domain objects and vice versa.
    /// </summary>
    public static class DtoToObjectConverter
    {
        #region Equipment

        public static EquipmentItem ConvertToItem(this EquipmentDTO dto)
        {
            return new EquipmentItem
            (
                dto.ID,
                dto.Title,
                dto.Description
            );
        }

        public static EquipmentDTO ConvertToDTO(this EquipmentItem item)
        {
            EquipmentDTO dto = new();
            dto.ID = item.ID;
            dto.Title = item.Title;
            dto.Description = item.Description;
            return dto;
        }

        public static EquipmentDTO UpdateFrom(this EquipmentDTO dto, EquipmentItem item)
        {
            dto.Title = item.Title;
            dto.Description = item.Description;
            return dto;
        }

        #endregion

        #region Room

        public static RoomItem ConvertToItem(this RoomDTO dto)
        {
            return new RoomItem(
                dto.ID,
                dto.RoomNumber,
                (RoomType) dto.RoomType,
                dto.Capacity,
                Convert.ToDecimal(dto.PricePerNight),
                (RoomAvailabilityStatus) dto.AvailabilityStatus
            );
        }

        public static RoomDTO ConvertToDTO(this RoomItem item)
        {
            RoomDTO dto = new();
            dto.ID = item.ID;
            dto.RoomNumber = item.RoomNumber;
            dto.RoomType = (int) item.RoomType;
            dto.Capacity = item.Capacity;
            dto.PricePerNight = item.PricePerNight.ToString();
            dto.AvailabilityStatus = (int) item.AvailabilityStatus;
            return dto;
        }

        public static RoomDTO UpdateFrom(this RoomDTO dto, RoomItem item)
        {
            dto.RoomNumber = item.RoomNumber;
            dto.RoomType = (int) item.RoomType;
            dto.Capacity = item.Capacity;
            dto.PricePerNight = item.PricePerNight.ToString();
            dto.AvailabilityStatus = (int) item.AvailabilityStatus;
            return dto;
        }

        #endregion

        #region Guest

        public static GuestItem ConvertToItem(this GuestDTO dto)
        {
            return new GuestItem
            (
                dto.ID,
                dto.Name,
                dto.Surname,
                dto.Email,
                dto.PhoneNumber
            );
        }

        public static GuestDTO ConvertToDTO(this GuestItem item)
        {
            GuestDTO dto = new();
            dto.ID = item.ID;
            dto.Name = item.Name;
            dto.Surname = item.Surname;
            dto.Email = item.Email;
            dto.PhoneNumber = item.PhoneNumber;
            return dto;
        }

        public static GuestDTO UpdateFrom(this GuestDTO dto, GuestItem item)
        {
            dto.Name = item.Name;
            dto.Surname = item.Surname;
            dto.Email = item.Email;
            dto.PhoneNumber = item.PhoneNumber;
            return dto;
        }

        #endregion

        #region Reservations

        public static ReservationItem ConvertToItem(this ReservationDTO dto)
        {
            return new ReservationItem
            (
                dto.ID,
                Convert.ToDateTime(dto.DateStart),
                Convert.ToDateTime(dto.DateEnd),
                (ReservationStatus) dto.State,
                dto.PriceTotal
            );
        }

        public static ReservationDTO ConvertToDTO(this ReservationItem item)
        {
            ReservationDTO dto = new();
            dto.ID = item.ID;
            dto.DateStart = item.DateStart.ToString();
            dto.DateEnd = item.DateEnd.ToString();
            dto.State = (int) item.State;
            dto.PriceTotal = (int) item.PriceTotal;
            return dto;
        }

        public static ReservationDTO UpdateFrom(this ReservationDTO dto, ReservationItem item)
        {
            dto.DateStart = item.DateStart.ToString();
            dto.DateEnd = item.DateEnd.ToString();
            dto.State = (int) item.State;
            dto.PriceTotal = (int) item.PriceTotal;
            return dto;
        }

        #endregion
    }
}