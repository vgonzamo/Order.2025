﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Orders.backend.Data;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Entites.Responses;

namespace Orders.backend.Repositories.Implementations;

public class GeneryRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GeneryRepository(DataContext context)
    {
        _context = context;
        _entity = _context.Set<T>();
    }
    public  virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {

                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {

            return ExceptionActionResponse(exception);

        }
    }


    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };
        }
        _entity.Remove(row);

        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true
            };
        }
        catch
        {
            return new ActionResponse<T>
            {
                Message = "No se puede borrar porque tiene registros relacionados."
            };
        }
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {

        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }
    

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()=> new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()

        };
        

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        _context.Update(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {

                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {

            return ExceptionActionResponse(exception);

        }
    }

    private ActionResponse<T> ExceptionActionResponse(Exception exception)=> 
    new ActionResponse<T>
        {
            Message = exception.Message
        };
    

    private ActionResponse<T> DbUpdateExceptionActionResponse()=>
    new ActionResponse<T>
        {
            Message = "El  registro ya existe"
        };
    
}
