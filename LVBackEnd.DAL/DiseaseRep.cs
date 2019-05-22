using SKG.DAL;
using SKG.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LVBackEnd.DAL
{
    using Models;
    public class DiseaseRep : GenericRep<ZContext, Disease>
    {
        #region -- Overrides --

        /// <summary>
        /// Create the models
        /// </summary>
        /// <param name="l">List model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Create(List<Disease> l)
        {
            return base.Create(l); //TODO
        }

        /// <summary>
        /// Read by
        /// </summary>
        /// <param name="p">Predicate</param>
        /// <returns>Return query data</returns>
        public override IQueryable<Disease> Read(Expression<Func<Disease, bool>> p)
        {
            return base.Read(p);
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Disease Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        /// <summary>
        /// Update the models
        /// </summary>
        /// <param name="l">List model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(List<Disease> l)
        {
            return base.Update(l); //TODO
        }

        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public override int Remove(int id)
        {
            return base.Remove(id); //TODO
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}
