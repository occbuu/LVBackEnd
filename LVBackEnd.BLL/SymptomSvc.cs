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
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Collections.Generic;

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

        public bool Check(string[] array, string[] array2)
        {
            foreach (var i in array)
            {
                if (array2.IndexOf(i.Trim()) == -1) return false;
            }
            return true;
        }

        public SingleRsp Diagnostic(List<int> req)
        {
            List<string> pre = new List<string>();
            List<string> lsOk = new List<string>();
            List<string> lsSymptom = new List<string>();

            foreach (var i in req)
            {
                pre.Add("{" + i + "}");
            }

            string[] sam = pre.ToArray();

            var ls = _rep.Context.Rule.Select(x => x.Vt).ToList();

            foreach (var vt in ls)
            {
                var sam2 = vt.Split(',');
                var check = Check(sam2, sam);
                if (check) lsOk.Add(vt);
            }

            lsSymptom = _rep.Context.Symptom.Where(x => req.Contains(x.Id)).Select(x => x.Name).ToList();

            var query = (from a in _rep.Context.Rule
                         join b in _rep.Context.Disease on a.Vp equals b.Code
                         where lsOk.Contains(a.Vt)
                         select new
                         {
                             a.Id,
                             a.Vt,
                             a.Vp,
                             a.RuleType,
                             b.Name
                         })
                         .OrderBy(o => o.RuleType)
                         .GroupBy(g => new { g.Name })
                         .Select(x => x.FirstOrDefault());

            var res = new SingleRsp
            {
                Data = new
                {
                    Symptom = lsSymptom,
                    Disease = query.ToList()
                }
            };

            return res;
        }

        #endregion

        #region -- Fields --

        #endregion
    }
}
