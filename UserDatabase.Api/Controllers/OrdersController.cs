
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDatabase.Api.Models;
using UserDatabase.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;


namespace UserDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/orders/monthly-amounts
        [HttpGet("monthly-amounts")]
        public ActionResult<IEnumerable<MonthlyAmountDetails>> GetMonthlyAmounts()
        {
            var monthlyAmounts = _context.ShippingOrder
                .Include(so => so.OrderedItem)
                .SelectMany(so => so.OrderedItem.Select(oi => new
                {
                    Year = so.order_date.Year,
                    Month = so.order_date.Month,
                    Amount = oi.price * oi.quantity, // Update this line to consider quantity
                }))
                .GroupBy(entry => new { entry.Year, entry.Month })
                .Select(group => new MonthlyAmountDetails
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    MonthlyAmount = group.Sum(entry => entry.Amount),
                })
                .OrderBy(entry => entry.Year)
                .ThenBy(entry => entry.Month)
                .ToList();

            return monthlyAmounts;
        }

        // GET: api/orders/yearly-amounts
        [HttpGet("yearly-amounts")]
        public ActionResult<IEnumerable<YearlyAmountDetails>> GetYearlyAmounts()
        {
            var yearlyAmounts = _context.ShippingOrder
                .Include(so => so.OrderedItem)
                .SelectMany(so => so.OrderedItem.Select(oi => new
                {
                    Year = so.order_date.Year,
                    Amount = oi.price * oi.quantity, // Update this line to consider quantity
                }))
                .GroupBy(entry => entry.Year)
                .Select(group => new YearlyAmountDetails
                {
                    Year = group.Key,
                    YearlyAmount = group.Sum(entry => entry.Amount)
                })
                .OrderBy(entry => entry.Year)
                .ToList();

            return yearlyAmounts;
        }




    }
}