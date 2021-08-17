using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using TimeSheets.DTO;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _repositories;

        public CustomersController(ICustomersRepository repositories)
        {
            _repositories = repositories;
        }

        /// <summary>
        /// Добавляет нового покупателя
        /// </summary>
        /// <param name="customer">Покупатель</param>
        /// <returns>Строка об успешной регистрации</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            await _repositories.CreateObjects(customer);
            return Ok("Регистрация прошла успешно!");
        }

        /// <summary>
        /// Возвращает конкретный контракт конткретного покупателя 
        /// </summary>
        /// <param name="idC">ид покупателя</param>
        /// <param name="id">ид контракта</param>
        /// <returns>Контракт</returns>
        [HttpGet("{idC}/contract/{id}")]
        public async Task<IActionResult> GetContract([FromRoute] int idC, [FromRoute] int id)
        {
            
            return Ok();
        }

        /// <summary>
        /// Возвращает список контрактов покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список контрактов</returns>
        [HttpGet("{id}/contracts")]
        public async Task<IActionResult> GetContracts([FromRoute] int id)
        {
            
            return Ok();
        }

        /// <summary>
        /// Возвращает конкретный счет конкретного покупателя
        /// </summary>
        /// <param name="idC">ид покупателя</param>
        /// <param name="id">ид счета</param>
        /// <returns>Счет</returns>
        [HttpGet("{idC}/invoice/{id}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int idC, [FromRoute] int id)
        {
            return Ok();
        }

        /// <summary>
        /// Возвращает счета конкретного покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список счетов</returns>
        [HttpGet("{id}/invoices")]
        public async Task<IActionResult> GetInvoicesById([FromRoute] int id)
        {
            
            return Ok();
        }

        /// <summary>
        /// Возвращает профиль покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns></returns>
        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            var customer = await _repositories.GetByIdCustomer(id);
            return Ok(customer);
        }

        /// <summary>
        /// Редактирует профиль покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <param name="customer">покупатель</param>
        /// <returns>Строка об успешном изменении</returns>
        [HttpPut("{id}/edit_profile_customer")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Customer customer)
        {
            await _repositories.UpdateObjects(id, customer);
            return Ok("Профиль успешно изменен!");
        }

        /// <summary>
        /// Удаляет профиль покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Срока об успешном удалении</returns>
        [HttpDelete("delete_profile_customer")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            await _repositories.DeleteObjects(id);
            return Ok("Профиль успешно удален!");
        }
    }
}
