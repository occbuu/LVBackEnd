using Newtonsoft.Json;
using SKG.BLL;
using SKG.Ext;
using SKG.Req;
using SKG.Rsp;
using System;
using System.Linq;

namespace LVBackEnd.BLL
{
    using DAL;
    using DAL.Models;
    using Filter;

    public class HuyLogSvc : GenericSvc<HuyLogRep, HuyLog>
    {
        #region -- Overrides --

        public override SearchRsp Read(PagingReq req)
        {
            var res = new SearchRsp(req);
            try
            {
                // Get data
                var filter = new HuyLogFilter();
                if (req.Filter != null)
                {
                    filter = JsonConvert.DeserializeObject<HuyLogFilter>(req.Filter.ToString());
                }
                var page = req.Page;
                var size = req.Size;
                var offset = (page - 1) * size;
                var query = All;

                #region -- Filter --

                if (filter.Duration != null)
                {
                    query = query.Where(p => p.Duration == filter.Duration);
                }

                if (!string.IsNullOrEmpty(filter.Source))
                {
                    query = query.Where(p => p.Source == filter.Source);
                }

                if (!string.IsNullOrEmpty(filter.Destination))
                {
                    query = query.Where(p => p.Destination == filter.Destination);
                }

                if (!string.IsNullOrEmpty(filter.Protocol))
                {
                    query = query.Where(p => p.Protocol == filter.Protocol);
                }

                if (filter.Length != null)
                {
                    query = query.Where(p => p.Length == filter.Length);
                }

                if (!string.IsNullOrEmpty(filter.Type))
                {
                    query = query.Where(p => p.Type == filter.Type);
                }

                #endregion

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
        public HuyLogSvc()
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
