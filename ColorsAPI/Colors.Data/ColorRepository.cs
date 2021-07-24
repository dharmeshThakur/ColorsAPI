using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colors.Data
{
    public class ColorRepository : IColorsRepository
    {
        private ApplicationContext context;
        private DbSet<Colors> colorEntity;

        public ColorRepository(ApplicationContext context)
        {
            this.context = context;
            colorEntity = context.Set<Colors>();
        }

        public Task<string> SaveColor(Colors color)
        {
            context.Entry(color).State = EntityState.Added;
            context.SaveChanges();
            return Task.FromResult("Success");
        }

        public Task<IEnumerable<Colors>> GetAllColors()
        {
            return Task.FromResult(colorEntity.AsEnumerable());
        }

        public Task<Colors> GetColor(long id)
        {
            return Task.FromResult(colorEntity.SingleOrDefault(s => s.Id == id));
        }

        public async Task<string> DeleteColor(long id)
        {
            Colors color = await GetColor(id);
            colorEntity.Remove(color);
            context.SaveChanges();
            return "Success";
        }

        public Task<string> UpdateColor(Colors color)
        {
            context.SaveChanges();
            return Task.FromResult("Success");
        }
    }
}
