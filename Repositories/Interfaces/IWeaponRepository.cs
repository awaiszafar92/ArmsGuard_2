using ARMSGUARD.Models;

namespace ARMSGUARD.Repositories.Interfaces;

public interface IWeaponRepository
{
    Task<IEnumerable<Weapon>> GetAllAsync();
    Task<Weapon?> GetByIdAsync(int weaponId);
    Task<int> AddAsync(Weapon weapon);
    Task<bool> UpdateAsync(Weapon weapon);
    Task<bool> DeleteAsync(int weaponId);
}
