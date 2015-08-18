using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls; //For SortBy method
using System.Web.Mvc;
using MVCDatatableApp.Models;


namespace MVCDatatableApp
{
    public class ResultSet
    {
        public List<Customer> GetResult(string search, string sortOrder, int start, int length, List<Customer> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult,columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int Count(string search, List<Customer> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }

        private IQueryable<Customer> FilterResult(string search, List<Customer> dtResult, List<string> columnFilters)
        {
            IQueryable<Customer> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null || (p.Name != null && p.Name.ToLower().Contains(search.ToLower()) || p.City != null && p.City.ToLower().Contains(search.ToLower())
                || p.Postal != null && p.Postal.ToLower().Contains(search.ToLower()) || p.Email != null && p.Email.ToLower().Contains(search.ToLower()) || p.Company != null && p.Company.ToLower().Contains(search.ToLower()) || p.Account != null && p.Account.ToLower().Contains(search.ToLower())
                || p.CreditCard != null && p.CreditCard.ToLower().Contains(search.ToLower()))) 
                && (columnFilters[0] == null || (p.Name != null && p.Name.ToLower().Contains(columnFilters[0].ToLower())))
                && (columnFilters[1] == null || (p.City != null && p.City.ToLower().Contains(columnFilters[1].ToLower())))
                && (columnFilters[2] == null || (p.Postal != null && p.Postal.ToLower().Contains(columnFilters[2].ToLower())))
                && (columnFilters[3] == null || (p.Email != null && p.Email.ToLower().Contains(columnFilters[3].ToLower())))
                && (columnFilters[4] == null || (p.Company != null && p.Company.ToLower().Contains(columnFilters[4].ToLower())))
                && (columnFilters[5] == null || (p.Account != null && p.Account.ToLower().Contains(columnFilters[5].ToLower())))
                && (columnFilters[6] == null || (p.CreditCard != null && p.CreditCard.ToLower().Contains(columnFilters[6].ToLower())))
                );

            return results;
        }
    }
}