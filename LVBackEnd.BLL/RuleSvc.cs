using Newtonsoft.Json;
using SKG.BLL;
using SKG.Ext;
using SKG.Req;
using SKG.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVBackEnd.BLL
{
    using DAL;
    using DAL.Models;
    using Filter;

    public class RuleSvc : GenericSvc<RuleRep, Rule>
    {
        #region -- Overrides --

        public override SearchRsp Read(PagingReq req)
        {
            var res = new SearchRsp(req);
            try
            {
                // Get data
                var filter = new CodeFilter();
                if (req.Filter != null)
                {
                    filter = JsonConvert.DeserializeObject<CodeFilter>(req.Filter.ToString());
                }
                var page = req.Page;
                var size = req.Size;
                var offset = (page - 1) * size;
                var query = All;

                res.TotalRecords = query.Count();

                if (req.Paging)
                {
                    query = query.OrderByDescending(p => p.Id)
                        .Sort(req.Sort)
                        .Skip(offset)
                        .Take(size);
                }

                var t = query.ToList();

                res.Data = t;
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }

            return res;
        }
        #endregion


        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public RuleSvc()
        {

        }



        #endregion


        #region -- Fields --

        /// <summary>
        /// Code type rep
        /// </summary>


        #endregion
    }
}
