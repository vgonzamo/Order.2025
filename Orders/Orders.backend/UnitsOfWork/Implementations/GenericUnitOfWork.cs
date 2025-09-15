﻿using Orders.backend.UnitsOfWork.Interfaces;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Entites.Responses;

namespace Orders.backend.UnitsOfWork.Implementations;

public  class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;
    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    public async Task<ActionResponse<T>> AddAsync(T entity)=>
    await _repository.AddAsync(entity);

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)=>
    await _repository.DeleteAsync(id);

    public  virtual async Task<ActionResponse<T>> GetAsync(int id)=>
    await _repository.GetAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()=>
    await _repository.GetAsync();

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)=>
    await _repository.UpdateAsync(entity);

}
