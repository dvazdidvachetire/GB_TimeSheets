using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DTO;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using Job = TimeSheets.DAL.Models.Job;

namespace TimeSheets.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerController(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        /// <summary>
        /// Создает задачи
        /// </summary>
        /// <param name="task">Задача</param>
        /// <returns>Список задач</returns>
        [HttpPost("task")]
        public async Task<IActionResult> CreateTask([FromBody] Job task)
        {
            return Ok(await _managerRepository.CreateTask(task));
        }

        /// <summary>
        /// Создает контракты
        /// </summary>
        /// <param name="contract">Контракт</param>
        /// <returns>Список контрактов</returns>
        [HttpPost("contract")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            return Ok(await _managerRepository.CreateContract(contract));
        }

        /// <summary>
        /// Формирует счет
        /// </summary>
        /// <param name="invoice">Счет</param>
        /// <returns>Счет</returns>
        [HttpPost("invoice")]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            return Ok();
        }

        /// <summary>
        /// Возвращает контракты конкретного покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список контрактов конкретного покупателя</returns>
        [HttpGet("{id}/customer_contracts")]
        public async Task<IActionResult> GetContractById([FromRoute] int id)
        {
            var contracts = await _managerRepository.GetByIdContracts(id);
            return Ok(contracts);
        }

        /// <summary>
        /// Возвращает счета конкретного покупателя
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Список счетов конкретного покупателя</returns>
        [HttpGet("{id}/customer_invoices")]
        public IActionResult GetInvoicesById([FromRoute] int id)
        {
            return Ok();
        }

        /// <summary>
        /// Возвращает все контракты
        /// </summary>
        /// <returns>Список контрактов</returns>
        [HttpGet("contracts")]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _managerRepository.GetAllContracts());
        }

        /// <summary>
        /// Возвращает все счета
        /// </summary>
        /// <returns>Список счетов</returns>
        [HttpGet("exposed_invoices")]
        public IActionResult GetAllInvoices()
        {
            return Ok();
        }
    }
}
