using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<SuperHero>> GetAllHeroes()
    {
        var superHeroes = await _context.SuperHeroes.ToListAsync();
        return superHeroes;
    }

    public async Task<SuperHero>? GetSingleHero(int id)
    {
        var superHero = await _context.SuperHeroes.FindAsync(id);
        if (superHero == null)
        {
            return null;
        }

        return superHero;
    }

    public async Task<List<SuperHero>>? AddHero(SuperHero hero)
    {
        
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();

        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>>? UpdateHero(int id, SuperHero request)
    {
        var superHero = await _context.SuperHeroes.FindAsync(id);

        if (superHero == null)
        {
            return null;
        }


        _context.SuperHeroes.Update(request);
        await _context.SaveChangesAsync();
        
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>>? DeleteHero(int id)
    {
        var superHero = await _context.SuperHeroes.FindAsync(id);

        if (superHero == null)
        {
            return null;
        }

        _context.SuperHeroes.Remove(superHero);

        return await _context.SuperHeroes.ToListAsync();
    }
}