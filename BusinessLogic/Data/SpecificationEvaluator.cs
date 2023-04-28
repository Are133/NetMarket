﻿using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLogic.Data
{
    public class SpecificationEvaluator<T> where T : BaseClass
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            if (specification.Criteria is not null)
                inputQuery = inputQuery.Where(specification.Criteria);

            inputQuery = specification.Includes.Aggregate(inputQuery, (current, include) =>
            current.Include(include));

            return inputQuery;
        }
    }
}
