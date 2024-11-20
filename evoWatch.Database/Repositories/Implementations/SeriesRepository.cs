﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class SeriesRepository : ISeriesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SeriesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Series> AddSeriesAsync(Series series)
        {
            var result = _databaseContext.Series.Add(series);
            await _databaseContext.SaveChangesAsync();


            return result.Entity;
            
        }
        public async Task<List<Series>> GetSeriesAsync()
        {
            return await _databaseContext.Series.ToListAsync();
        }

        public async Task<bool> DeleteSeriesAsync(Series series)
        {
            try
            {
                var result = _databaseContext.Series.Remove(series);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException){
                 
                return false;   
            }

            
        }

        //UPDATE
        public async Task<Series?> GetSeriesByIdAsync(Guid id)
        {
            return await _databaseContext.Series.FindAsync(id);

        }

        public async Task<Series> UpdateSeriesAsync(Series series)
        {
            var result = _databaseContext.Series.Update(series);
            await _databaseContext.SaveChangesAsync();

           return result.Entity;
            
        }

        


    }
}