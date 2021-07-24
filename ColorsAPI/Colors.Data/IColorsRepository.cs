using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Colors.Data
{
    public interface IColorsRepository
    {
        Task<string> SaveColor(Colors color);
        Task<IEnumerable<Colors>> GetAllColors();
        Task<Colors> GetColor(long id);
        Task<string> DeleteColor(long id);
        Task<string> UpdateColor(Colors color);
    }
}
