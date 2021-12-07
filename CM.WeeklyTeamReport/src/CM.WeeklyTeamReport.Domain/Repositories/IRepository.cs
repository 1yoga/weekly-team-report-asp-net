﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Read(int entityId);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> ReadAll(int? entityId);
    }
}