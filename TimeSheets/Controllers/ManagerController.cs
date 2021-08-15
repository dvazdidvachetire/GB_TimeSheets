using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheets.DTO;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly Repositories _repositories;

        public ManagerController(Repositories repositories)
        {
            _repositories = repositories;
        }

        /// <summary>
        /// Создает задачи
        /// </summary>
        /// <param name="task">Задача</param>
        /// <returns>Список задач</returns>
        [HttpPost("task")]
        public IActionResult CreateTask([FromBody] Task task)
        {
            _repositories.Tasks.Add(task);
            return Ok(_repositories.Tasks);
        }

        /// <summary>
        /// Создает контракты
        /// </summary>
        /// <param name="contract">Контракт</param>
        /// <returns>Список контрактов</returns>
        [HttpPost("contract")]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == contract.CustomerId);
            var tasks = _repositories.Tasks.Where(t => t.CustomerId == customer?.Id);
            var contractDto = new ContractDto
            {
                Id = contract.Id,
                NumberContract = contract.NumberContract,
                Customer = customer,
                Tasks = tasks
            };

            _repositories.Contracts.Add(contractDto);

            return Ok(_repositories.Contracts);
        }

        /// <summary>
        /// Формирует счет
        /// </summary>
        /// <param name="invoice">Счет</param>
        /// <returns>Счет</returns>
        [HttpPost("invoice")]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == invoice.CustomerId);
            var tasks = _repositories.TaskDtos.Where(t => t.CustomerId == customer.Id).ToList();

            var totalSum = tasks.Select(t => t.Amount).Sum();

            var invoiceDto = new InvoiceDto
            {
                Id = invoice.Id,
                Customer = customer,
                Tasks = tasks,
                TotalSum = totalSum
            };

            _repositories.InvoiceDtos.Add(invoiceDto);

            return Ok(invoiceDto);
        }

        /// <summary>
        /// Возвращает контракты конкретного покупателя
        /// </summary>
        /// <param name="id">ид покупателя</param>
        /// <returns>Список контрактов конкретного покупателя</returns>
        [HttpGet("{id}/customer_contracts")]
        public IActionResult GetContractById([FromRoute] int id)
        {
            var contracts = _repositories.Contracts.Where(c => c.Customer.Id == id);
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
            var invoices = _repositories.InvoiceDtos.Where(i => i.Customer.Id == id);
            return Ok(invoices);
        }

        /// <summary>
        /// Возвращает все контракты
        /// </summary>
        /// <returns>Список контрактов</returns>
        [HttpGet("contracts")]
        public IActionResult GetAllContracts()
        {
            return Ok(_repositories.Contracts);
        }

        /// <summary>
        /// Возвращает все счета
        /// </summary>
        /// <returns>Список счетов</returns>
        [HttpGet("exposed_invoices")]
        public IActionResult GetAllInvoices()
        {
            return Ok(_repositories.InvoiceDtos);
        }
    }
}
