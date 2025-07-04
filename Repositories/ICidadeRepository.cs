﻿using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface ICidadeRepository
    {
        Task<List<Cidade>> GetCidadeEstado(int estadoId);

        Task<List<Cidade>> GetCidade();
    }
}
