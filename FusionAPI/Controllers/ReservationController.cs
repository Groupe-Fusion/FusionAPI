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
        private readonly IGetAllReservationsUseCase _getAllReservationsUseCase;
        private readonly IGetReservationByIdUseCase _getReservationByIdUseCase;
        private readonly IDeleteReservationUseCase _deleteReservationUseCase;

        public ReservationController(
            IAddReservationUseCase addReservationUseCase,
            IGetAllReservationsUseCase getAllReservationsUseCase,
            IGetReservationByIdUseCase getReservationByIdUseCase,
            IDeleteReservationUseCase deleteReservationUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
            _getAllReservationsUseCase = getAllReservationsUseCase;
            _getReservationByIdUseCase = getReservationByIdUseCase;
            _deleteReservationUseCase = deleteReservationUseCase;
        }

        /// <summary>
        /// Ajouter une nouvelle réservation.
        /// </summary>
        [HttpPost()]
        public async Task<IActionResult> AddReservation([FromBody] ReservationRequest reservationRequest, CancellationToken ct)
        {
            try
            {
                // Map ReservationRequest to Reservation
                var reservation = new Reservation
                {
                    Name = reservationRequest.Name,
                    Description = reservationRequest.Description,
                    UserId = reservationRequest.UserId,
                    CreatedByName = reservationRequest.CreatedByName,
                    User = new User { FirstName = reservationRequest.Name, LastName = reservationRequest.Name},
                    StartLocation = reservationRequest.StartLocation,
                    EndLocation = reservationRequest.EndLocation,
                    Dimension = reservationRequest.Dimension,
                    Weight = reservationRequest.Weight,
                    IsNow = reservationRequest.IsNow,
                    DeliveryDate = reservationRequest.DeliveryDate
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
    }
}