using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace _5MI.ReservationManager.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IAddReservationUseCase _addReservationUseCase;
        private readonly IUpdateReservationUseCase _updateReservationUseCase;
        private readonly IGetAllReservationsUseCase _getAllReservationsUseCase;
        private readonly IGetReservationByIdUseCase _getReservationByIdUseCase;
        private readonly IDeleteReservationUseCase _deleteReservationUseCase;
        private readonly IGetAllReservationsByUserIdUseCase _getAllReservationsByUserIdUseCase;

        public ReservationController(
            IAddReservationUseCase addReservationUseCase,
            IUpdateReservationUseCase updateReservationUseCase,
            IGetAllReservationsUseCase getAllReservationsUseCase,
            IGetReservationByIdUseCase getReservationByIdUseCase,
            IDeleteReservationUseCase deleteReservationUseCase,
            IGetAllReservationsByUserIdUseCase getAllReservationsByUserIdUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
            _getAllReservationsUseCase = getAllReservationsUseCase;
            _getReservationByIdUseCase = getReservationByIdUseCase;
            _deleteReservationUseCase = deleteReservationUseCase;
            _updateReservationUseCase = updateReservationUseCase;
            _getAllReservationsByUserIdUseCase = getAllReservationsByUserIdUseCase;
        }

        /// <summary>
        /// Ajouter une nouvelle réservation.
        /// </summary>
        [HttpPost()]
        public async Task<IActionResult> AddReservation([FromBody] ReservationRequest reservationRequest, CancellationToken ct)
        {
            try
            {
                var reservation = new Reservation
                {
                    Name = reservationRequest.Name,
                    Description = reservationRequest.Description,
                    UserId = reservationRequest.UserId,
                    CreatedByName = reservationRequest.CreatedByName,
                    //User = new User { FirstName = reservationRequest.CreatedByName, LastName = reservationRequest.CreatedByName },
                    StartLocation = reservationRequest.StartLocation,
                    EndLocation = reservationRequest.EndLocation,
                    Dimension = reservationRequest.Dimension,
                    Weight = reservationRequest.Weight,
                    IsNow = reservationRequest.IsNow,
                    DeliveryDate = reservationRequest.DeliveryDate,
                    Category = reservationRequest.Category,
                    Rating = reservationRequest.Rating,
                    Price = reservationRequest.Price,
                    InHour = reservationRequest.InHour,
                    RecipientName = reservationRequest.RecipientName,
                    RecipientPhone = reservationRequest.RecipientPhone,
                    RecipientAddress = reservationRequest.RecipientAddress,
                    RecipientCity = reservationRequest.RecipientCity,
                    RecipientPostalCode = reservationRequest.RecipientPostalCode,
                    PackageType = reservationRequest.PackageType,
                    isFragile = reservationRequest.isFragile,
                    ReservationStatus = reservationRequest.ReservationStatus
                };

                var result = await _addReservationUseCase.ExecuteAsync(reservation, ct);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Récupérer toutes les réservations.
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAllReservations(CancellationToken ct)
        {
            try
            {
                var reservations = await _getAllReservationsUseCase.ExecuteAsync(ct);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"error {ex.Message}");
            }
        }

        /// <summary>
        /// Récupérer une réservation par son id.
        /// </summary>
        [HttpGet("{reservationId}")]
        public async Task<IActionResult> GetReservationById(int reservationId, CancellationToken ct)
        {
            try
            {
                var reservation = await _getReservationByIdUseCase.ExecuteAsync(reservationId, ct);
                return Ok(reservation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"reservation Not found");
            }
        }

        /// <summary>
        /// Récupérer une réservation par son id.
        /// </summary>
        [HttpPut("{reservationId}")]
        public async Task<IActionResult> UpdateReservationById(
            [FromBody] ReservationRequest reservationRequest,
            int reservationId,  
            CancellationToken ct)
        {
            try
            {
                var reservation = new Reservation
                {
                    Name = reservationRequest.Name,
                    Description = reservationRequest.Description,
                    UserId = reservationRequest.UserId,
                    PrestataireId = reservationRequest.PrestataireId,
                    CreatedByName = reservationRequest.CreatedByName,
                    User = new User { FirstName = reservationRequest.Name, LastName = reservationRequest.Name },
                    StartLocation = reservationRequest.StartLocation,
                    EndLocation = reservationRequest.EndLocation,
                    Dimension = reservationRequest.Dimension,
                    Weight = reservationRequest.Weight,
                    IsNow = reservationRequest.IsNow,
                    DeliveryDate = reservationRequest.DeliveryDate,
                    Category = reservationRequest.Category,
                    Rating = reservationRequest.Rating,
                    Price = reservationRequest.Price,
                    InHour = reservationRequest.InHour,
                    RecipientName = reservationRequest.RecipientName,
                    RecipientPhone = reservationRequest.RecipientPhone,
                    RecipientAddress = reservationRequest.RecipientAddress,
                    RecipientCity = reservationRequest.RecipientCity,
                    RecipientPostalCode = reservationRequest.RecipientPostalCode,
                    PackageType = reservationRequest.PackageType,
                    isFragile = reservationRequest.isFragile,
                    ReservationStatus = reservationRequest.ReservationStatus
                };

                reservation = await _updateReservationUseCase.ExecuteAsync(
                    reservationId,
                    reservation, 
                    ct);

                return Ok(reservation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"reservation Not found");
            }
        }

        /// <summary>
        /// Supprime une réservation par son id.
        /// </summary>
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId, CancellationToken ct)
        {
            try
            {
                var reservation = await _deleteReservationUseCase.ExecuteAsync(reservationId, ct);
                if (reservation is null)
                    return NotFound("Reservation not found");

                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReservationByUserId(int userId, CancellationToken ct)
        {
            try
            {
                var reservation = await _getAllReservationsByUserIdUseCase.ExecuteAsync(userId, ct);
                return Ok(reservation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"reservation Not found");
            }
        }
    }
}