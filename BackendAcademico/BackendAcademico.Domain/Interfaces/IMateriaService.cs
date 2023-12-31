﻿using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<MateriaModel>> GetMateriasAsync();
    }
}
