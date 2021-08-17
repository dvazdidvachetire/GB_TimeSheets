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
        private readonly Repositories _repositoriesT;

        public CustomersController(ICustomersRepository repositories, Repositories repositoriesT)
        {
            _repositories = repositories;
            _repositoriesT = repositoriesT;
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
        public IActionResult GetContract([FromRoute] int idC, [FromRoute] int id)
        {
            var contracts = _repositoriesT.Contracts.Where(c => c.Customer.Id == idC);
            var contract = contracts.SingleOrDefault(c => c.Id == id);
            return Ok(contract);
        }

        /// <summary>
        /// Возвращает список контрактов покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список контрактов</returns>
        [HttpGet("{id}/contracts")]
        public IActionResult GetContracts([FromRoute] int id)
        {
            var contracts = _repositoriesT.Contracts.Where(c => c.Customer.Id == id);
            return Ok(contracts);
        }

        /// <summary>
        /// Возвращает конкретный счет конкретного покупателя
        /// </summary>
        /// <param name="idC">ид покупателя</param>
        /// <param name="id">ид счета</param>
        /// <returns>Счет</returns>
        [HttpGet("{idC}/invoice/{id}")]
        public IActionResult GetInvoice([FromRoute] int idC, [FromRoute] int id)
        {
            var invoices = _repositoriesT.InvoiceDtos.Where(i => i.Customer.Id == idC);
            var invoice = invoices.SingleOrDefault(i => i.Id == id);
            return Ok(invoice);
        }

        /// <summary>
        /// Возвращает счета конкретного покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список счетов</returns>
        [HttpGet("{id}/invoices")]
        public IActionResult GetInvoicesById([FromRoute] int id)
        {
            var invoices = _repositoriesT.InvoiceDtos.Where(i => i.Customer.Id == id);
            return Ok(invoices);
        }

        /// <summary>
        /// Возвращает профиль покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns></returns>
        [HttpGet("{id}/profile")]
        public IActionResult GetProfile([FromRoute] int id)
        {
            var customer = _repositories.GetObject(id);
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
            await _repositories.UpdateObject(id, customer);
            return await Task.Run(() => Ok("Профиль успешно изменен!"));
        }

        /// <summary>
        /// Удаляет профиль покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Срока об успешном удалении</returns>
        [HttpDelete("delete_profile_customer")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            await _repositories.DeleteObject(id);
            return await Task.Run(() => Ok("Профиль успешно удален!"));
        }
    }
}
