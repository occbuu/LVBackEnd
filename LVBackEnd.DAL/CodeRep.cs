using SKG.DAL;
using SKG.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LVBackEnd.DAL
{
    using Models;

    /// <summary>
    /// Code repository
    /// </summary>
    public class CodeRep : GenericRep<ZContext, Code>
    {
        #region -- Overrides --

        /// <summary>
        /// Create the models
        /// </summary>
        /// <param name="l">List model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Create(List<Code> l)
        {
            return base.Create(l); //TODO
        }

        /// <summary>
        /// Read by
        /// </summary>
        /// <param name="p">Predicate</param>
        /// <returns>Return query data</returns>
        public override IQueryable<Code> Read(Expression<Func<Code, bool>> p)
        {
            return base.Read(p);
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Code Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        /// <summary>
        /// Update the models
        /// </summary>
        /// <param name="l">List model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(List<Code> l)
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