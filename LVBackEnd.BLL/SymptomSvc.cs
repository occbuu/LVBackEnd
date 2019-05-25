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

    public class SymptomSvc : GenericSvc<SymptomRep, Symptom>
    {
        #region -- Overrides --

        public override SearchRsp Read(PagingReq req)
        {
            var res = new SearchRsp(req);
            try
            {
                // Get data
                var filter = new SymptomFilter();
                if (req.Filter != null)
                {
                    filter = JsonConvert.DeserializeObject<SymptomFilter>(req.Filter.ToString());
                }

                var page = req.Page;
                var size = req.Size;
                var offset = (page - 1) * size;
                var query = All;

                #region -- Filter --

                if (filter.Type != null)
                {
                    query = query.Where(p => p.Group == filter.Type);
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
        public SymptomSvc() { }

        /// <summary>
        /// Read symptom type 
        /// </summary>
        /// <returns>Return the result</returns>
        public SingleRsp ReadSymptomType()
        {
            var res = new SingleRsp
            {
                Data = _rep.Context.Symptom.Select(x => x.Group).ToList().Distinct()
            };

            return res;
        }

        #endregion

        #region -- Fields --

        #endregion
    }
}
